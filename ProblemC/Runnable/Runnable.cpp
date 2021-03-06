// Runnable.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include "../ProblemC/ProblemC.h"

void draw_map(unsigned char* pMap, PointAttributes* points, int height, int width, int start, int end) {
	for (int y = height - 1; y >= 0; --y) {
		for (int x = 0; x < width; ++x) {
			auto indice = y * width + x;
			auto point = points[indice];
			if (start == indice) std::cout << "X";
			else if (end == indice) std::cout << "0";
			else if (pMap[indice] == '*') std::cout << '*';
			else if (pMap[indice] == 0) std::cout << '@';
			else if (point.came_from != -1)
				std::cout << '%';
			else if (pMap[indice] == 1) std::cout << ' ';
		}
		std::cout << std::endl;
	}
}

int main()
{
	//auto width = 14;
	//auto height = 21;
	//unsigned char pMap[] = {
	//	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
	//	1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
	//	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
	//};
	//int pOutBuffer[100];

	//PointAttributes* point_attributes = new PointAttributes[width * height];
	//std::fill(point_attributes, point_attributes + width * height, PointAttributes{ INT_MAX, -1 });

	//const int startX = 6;
	//const int startY = 20;
	//const int endX = 6;
	//const int endY = 0;

	//auto res = FindPath(startX, startY, endX, endY, pMap, width, height, pOutBuffer, 100, point_attributes);

	//for (int i = 0; i < res; ++i) {
	//	pMap[pOutBuffer[i]] = '*';
	//}
	//std::cout << "Steps: " << res << std::endl;
	//draw_map(pMap, point_attributes, height, width, startY * width + startX, endY * width + endX);

	return 0;
}




