#pragma once

#include <climits>


struct Point {
	int x;
	int y;
};

struct PointAttributes {
	int cost_sum = INT_MAX;
	int came_from = -1;
};

struct PointQueueItem {
	PointQueueItem(int p, int i) : indice(i), priority(p) {}

	int priority;
	int indice;
};

int FindPath(const int nStartX, const int nStartY,
	const int nTargetX, const int nTargetY,
	const unsigned char* pMap, const int nMapWidth, const int nMapHeight,
	int* pOutBuffer, const int nOutBufferSize, PointAttributes* point_attributes);

void get_neighbors(int* const neighbors, const int currentIndice, const int nMapHeight, const int nMapWidth);
