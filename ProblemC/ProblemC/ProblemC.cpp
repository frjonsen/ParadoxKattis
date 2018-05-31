// ProblemC.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ProblemC.h"
#include <queue>
#include <map>

using namespace std;

inline int distance(const int from, const int to, const int nMapWidth) {
	auto yDiff = abs(from / nMapWidth - to / nMapWidth);
	auto xDiff = abs(from % nMapWidth - to % nMapWidth);

	return yDiff + xDiff;
}

inline void get_neighbors(int* const neighbors, const int currentIndice, const int nMapHeight, const int nMapWidth) {
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

	Point endPoint = Point{ nTargetX, nTargetY };
	int end = nTargetY * nMapWidth + nTargetX;
	
	map<int, PointAttributes> point_attributes{ {start, PointAttributes{ 0 } } };
	auto compare = [](const PointQueueItem& p1, const PointQueueItem& p2) { return p1.indice > p2.indice; };
	priority_queue<PointQueueItem, vector<PointQueueItem>, decltype(compare)> frontier(compare);
	auto start_queue = PointQueueItem{ start, 0 };
	frontier.push(start_queue);
	int neighbors[4];
	PointAttributes& current_attributes = point_attributes[start];
	PointQueueItem& current = start_queue;

	while (!frontier.empty()) {
		current = frontier.top();
		current_attributes = point_attributes[current.indice];
		if (current.indice == end)
			break;

		get_neighbors(neighbors, current.indice, nMapHeight, nMapWidth);

		for (int i = 0; i < 4; ++i) {
			if (neighbors[i] == -1 || pMap[neighbors[i]] == '0') continue;
			PointAttributes& attr = point_attributes[neighbors[i]];
			if (attr.came_from == -1 || attr.cost_sum > current_attributes.cost_sum + 1) {
				attr.came_from = current.indice;
				attr.cost_sum = current_attributes.cost_sum + 1;

				auto neighbor = PointQueueItem{ neighbors[i], distance(neighbors[i], end, nMapWidth) };
				frontier.push(neighbor);
			}
		}

		frontier.pop();
	}

	// Didn't find a path
	if (current.indice != end) return -1;
	if (nOutBufferSize < current_attributes.cost_sum) return -1;

	int sum = current_attributes.cost_sum;
	pOutBuffer[sum - 1] = end;
	for (int i = 0; i < sum; ++i) {
		if (current_attributes.came_from == start) break;
		pOutBuffer[sum - i - 2] = current_attributes.came_from;
		current_attributes = point_attributes[current_attributes.came_from];
	}

	return sum;
}

