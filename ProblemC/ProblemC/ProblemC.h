#pragma once

#include <climits>

struct Point {
	int x;
	int y;

	bool operator < (const Point& p2) {
		if (x == p2.x) return y < p2.y;

		return x < p2.x;
	}
};

struct PointAttributes {
	int cost_sum = INT_MAX;
	int came_from = -1;
};

struct PointQueueItem {
	int indice;
	int priority;
};

int FindPath(const int nStartX, const int nStartY,
	const int nTargetX, const int nTargetY,
	const unsigned char* pMap, const int nMapWidth, const int nMapHeight,
	int* pOutBuffer, const int nOutBufferSize);

int distance(const Point& from, const Point& to);
int distance(const int from, const int to, const int nMapWidth);
Point from_indice(const int indice, const int mapWidth);
int to_indice(const Point& p, int mapWidth);
void get_neighbors(int* const neighbors, const Point& current, const int nMapHeight, const int nMapWidth);
