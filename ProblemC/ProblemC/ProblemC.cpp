// ProblemC.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ProblemC.h"
#include <queue>
#include <cmath>
using namespace std;

void get_neighbors(int* const neighbors, const int currentIndice, const int nMapHeight, const int nMapWidth) {
	int x = currentIndice % nMapWidth;
	int y = currentIndice / nMapWidth;

	neighbors[0] = x > 0 ? x - 1 + y * nMapWidth : -1;
	neighbors[1] = x < (nMapWidth - 1) ? x + 1 + y * nMapWidth : -1;
	neighbors[2] = y > 0 ? x + (y - 1)  * nMapWidth : -1;
	neighbors[3] = y < (nMapHeight - 1) ? x + (y + 1)  * nMapWidth : -1;
}

int FindPath(const int nStartX, const int nStartY,
	const int nTargetX, const int nTargetY,
	const unsigned char* pMap, const int nMapWidth, const int nMapHeight,
	int* pOutBuffer, const int nOutBufferSize) {

	int start = nStartY * nMapWidth + nStartX;
	int end = nTargetY * nMapWidth + nTargetX;

	PointAttributes* point_attributes = new PointAttributes[nMapWidth * nMapHeight];

	auto compare = [](const PointQueueItem& p1, const PointQueueItem& p2) { return p1.priority > p2.priority; };

	vector<PointQueueItem> container;
	container.reserve(nMapWidth * nMapHeight);
	priority_queue<PointQueueItem, decltype(container), decltype(compare)> frontier(compare, container);
	frontier.emplace(PointQueueItem{ 0, start });

	int neighbors[4];
	PointAttributes& current_attributes = point_attributes[start];
	auto current = frontier.top();

	current_attributes.cost_sum = 0;

	while (!frontier.empty()) {
		current = frontier.top();
		frontier.pop();
		current_attributes = point_attributes[current.indice];
		if (current.indice == end)
			break;

		get_neighbors(neighbors, current.indice, nMapHeight, nMapWidth);

		for (int i = 0; i < 4; ++i) {
			if (neighbors[i] == -1 || pMap[neighbors[i]] == 0) continue;
			auto& neighbor_attr = point_attributes[neighbors[i]];
			if (neighbor_attr.came_from == -1 || neighbor_attr.cost_sum > current_attributes.cost_sum + 1) {
				neighbor_attr.came_from = current.indice;
				neighbor_attr.cost_sum = current_attributes.cost_sum + 1;
				int cost = abs(neighbors[i] % nMapWidth - end % nMapWidth) + abs(neighbors[i] / nMapWidth - end / nMapWidth);
				frontier.push(PointQueueItem{ cost + neighbor_attr.cost_sum, neighbors[i] });
			}
		}
	}

	
	if (current.indice != end) return -1; // Didn't find a path
	if (nOutBufferSize < current_attributes.cost_sum) return current_attributes.cost_sum; // Path was too long

	int sum = current_attributes.cost_sum;
	pOutBuffer[sum > 0 ? sum - 1 : 0] = end; // Just in case starting point and end point is the same
	for (int i = 0; i < sum; ++i) {
		if (current_attributes.came_from == start) break;
		pOutBuffer[sum - i - 2] = current_attributes.came_from;
		current_attributes = point_attributes[current_attributes.came_from];
	}
	delete point_attributes;
	return sum;
}
