// ProblemC.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ProblemC.h"
#include <queue>
#include <map>

using namespace std;

int distance(const Point& from, const Point& to) {
	return abs(from.x - to.x) + abs(from.y - to.y);
}

int distance(const int from, const int to, const int nMapWidth) {
	auto yDiff = abs(from / nMapWidth - to / nMapWidth);
	auto xDiff = abs(from % nMapWidth - to % nMapWidth);

	return yDiff + xDiff;
}

int to_indice(const Point& p, int mapWidth) {
	return p.y * mapWidth + p.x;
}

Point from_indice(const int indice, const int mapWidth) {
	return Point{
		indice % mapWidth,
		indice / mapWidth
	};
}

void get_neighbors(int* const neighbors, const Point& current, const int nMapHeight, const int nMapWidth) {
	neighbors[0] = current.x > 0 ? current.x - 1 + current.y * nMapWidth : -1;
	neighbors[1] = current.x < (nMapWidth - 1) ? current.x + 1 + current.y * nMapWidth : -1;
	neighbors[2] = current.y > 0 ? current.x + (current.y - 1)  * nMapWidth : -1;
	neighbors[3] = current.y < (nMapHeight - 1) ? current.x + (current.y + 1)  * nMapWidth : -1;
}

int FindPath(const int nStartX, const int nStartY,
	const int nTargetX, const int nTargetY,
	const unsigned char* pMap, const int nMapWidth, const int nMapHeight,
	int* pOutBuffer, const int nOutBufferSize) {

	int start =  to_indice(Point{ nStartX, nStartY }, nMapWidth);

	Point endPoint = Point{ nTargetX, nTargetY };
	int end = to_indice(endPoint, nMapWidth);
	
	map<int, PointAttributes> point_attributes{ {start, PointAttributes{ 0 } } };
	auto compare = [](const PointQueueItem& p1, const PointQueueItem& p2) { return p1.indice < p2.indice; };
	priority_queue<PointQueueItem, vector<PointQueueItem>, decltype(compare)> frontier(compare);
	frontier.push(PointQueueItem{ start, 0 });
	int neighbors[4];
	PointAttributes& current_attributes = point_attributes[start];
	PointQueueItem current;

	while (!frontier.empty()) {
		current = frontier.top();
		current_attributes = point_attributes[current.indice];
		if (current.indice == end) break;

		Point asPoint = from_indice(current.indice, nMapWidth);
		get_neighbors(neighbors, asPoint, nMapHeight, nMapWidth);

		for (int i = 0; i < 4; ++i) {
			if (neighbors[i] == -1 || pMap[neighbors[i]] == '0') continue;
			PointAttributes& attr = point_attributes[neighbors[i]];
			if (attr.came_from == -1 || attr.cost_sum > (current_attributes.cost_sum + 1)) {
				attr.came_from = current.indice;
				attr.cost_sum = current_attributes.cost_sum + 1;

				frontier.push(PointQueueItem{ neighbors[i], distance(neighbors[i], end, nMapWidth) });
			}
		}

		frontier.pop();
	}

	// Didn't find a path
	if (current.indice != end) return -1;
	if (nOutBufferSize < current_attributes.cost_sum) return -1;

	auto sum = current_attributes.cost_sum;
	for (int i = 0; i < sum; ++i) {
		if (current_attributes.came_from == start) break;
		pOutBuffer[sum - i - 1] = current_attributes.came_from;
	}

	return sum;
}

