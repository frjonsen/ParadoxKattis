// Runnable.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include "../ProblemC/ProblemC.h"
#include <numeric>
#include <chrono>

using namespace std;

void draw_map(unsigned char* pMap, PointAttributes* points, int height, int width, int start, int end) {
	//for (int y = height - 1; y >= 0; --y) {
	for (int y = 0; y < height; ++y) {
		for (int x = 0; x < width; ++x) {
			auto indice = y * width + x;
			auto point = points[indice];
			if (start == indice) std::cout << "S";
			else if (end == indice) std::cout << "E";
			else if (pMap[indice] == '*') std::cout << '*';
			else if (pMap[indice] == 0) std::cout << '@';
			else if (point.came_from != -1)
				std::cout << '%';
			else if (pMap[indice] == 1) std::cout << ' ';
		}
		std::cout << std::endl;
	}
}

vector<string> read_map(int& start, int& end) {
	vector<string> lines;
	ifstream file("sample.in");
	string line;
	if (!file.is_open()) throw 1;
	while (getline(file, line)) {
		auto s = line.find_first_of('S');
		if (s != string::npos) {
			start = s + lines.size() * line.length();
			line[s] = '1';
		}
		s = line.find_first_of('E');
		if (s != string::npos) {
			end = s + lines.size() * line.length();
			line[s] = '1';
		}
		lines.push_back(line);
	}

	file.close();
	return lines;
}

int main()
{
	const int bufferSize = 1000;
	int start = 0;
	int end = 0;
	auto file = read_map(start, end);
	int pOutBuffer[bufferSize];
	auto height = file.size();
	auto width = file[0].length();

	auto startX = start % width;
	auto startY = start / width;
	auto endX = end % width;
	auto endY = end / width;

	unsigned char* pMap = new unsigned char[width * height];

	for (size_t y = 0; y < height; ++y) {
		for (size_t x = 0; x < width; ++x) {
			auto read = file[y][x];
			char c = file[y][x] - '0';
			pMap[x + y * width] = c;
		}
	}
	auto t1 = std::chrono::high_resolution_clock::now();
	PointAttributes* point_attributes = new PointAttributes[width * height];
	std::fill(point_attributes, point_attributes + width * height, PointAttributes{ INT_MAX, -1 });
	auto res = FindPath(startX, startY, endX, endY, pMap, width, height, pOutBuffer, bufferSize, point_attributes);
	auto t2 = std::chrono::high_resolution_clock::now();

	for (int i = 0; i < res; ++i) {
		pMap[pOutBuffer[i]] = '*';
	}

	auto milliseconds = std::chrono::duration_cast<std::chrono::milliseconds>(t2 - t1).count();
	std::cout << "Steps: " << res << ". Milliseconds: " << milliseconds << std::endl;
	draw_map(pMap, point_attributes, height, width, startY * width + startX, endY * width + endX);
	delete pMap;
	return 0;
}




