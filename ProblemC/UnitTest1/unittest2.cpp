#include "stdafx.h"
#include "CppUnitTest.h"
#include "../ProblemC/ProblemC.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{
	TEST_CLASS(UnitTest2)
	{
	public:

		TEST_METHOD(Distance1)
		{
			const Point current{ 2, 0 };
			const Point target{ 1, 2 };
			const int expectedDistance = 3;

			auto res = distance(current, target);
			Assert::AreEqual(expectedDistance, res);
		}

		TEST_METHOD(Distance_NoDistance) {
			const Point current{ 2, 0 };
			const Point target{ 2, 0 };
			const int expectedDistance = 0;
			auto res = distance(current, target);
			Assert::AreEqual(expectedDistance, res);
		}

		TEST_METHOD(Distance2)
		{
			const Point current{ 2, 0 };
			const Point target{ 1, 2 };
			const int expectedDistance = 3;
			const int width = 4;

			auto res = distance(to_indice(current, width), to_indice(target, width), width);
			Assert::AreEqual(expectedDistance, res);
		}

		TEST_METHOD(Distance_NoDistance3) {
			const Point current{ 2, 0 };
			const Point target{ 2, 0 };
			const int expectedDistance = 0;
			const int width = 4;
			auto res = distance(to_indice(current, width), to_indice(target, width), width);
			Assert::AreEqual(expectedDistance, res);
		}

		TEST_METHOD(ToIndice1) {
			const Point p{ 2, 0 };
			const int width = 4;
			const int expected = 2;
			auto res = to_indice(p, width);

			Assert::AreEqual(res, expected);
		}

		TEST_METHOD(ToIndice2) {
			const Point p{ 2, 2 };
			const int width = 4;
			const int expected = 10;
			auto res = to_indice(p, width);

			Assert::AreEqual(res, expected);
		}

		TEST_METHOD(GetNeighbors1) {
			Point current{ 2, 2 };
			int neighbors[4];
			const int width = 5;
			get_neighbors(neighbors, current, 5, width);

			Assert::AreEqual(to_indice(Point{ 1, 2 }, width), neighbors[0]);
			Assert::AreEqual(to_indice(Point{ 3, 2 }, width), neighbors[1]);
			Assert::AreEqual(to_indice(Point{ 2, 1 }, width), neighbors[2]);
			Assert::AreEqual(to_indice(Point{ 2, 3 }, width), neighbors[3]);
		}

		TEST_METHOD(GetNeighbors_Lonely) {
			Point current{ 0, 0 };
			int neighbors[4];
			const int width = 1;
			get_neighbors(neighbors, current, 1, width);

			Assert::AreEqual(-1, neighbors[0]);
			Assert::AreEqual(-1, neighbors[1]);
			Assert::AreEqual(-1, neighbors[2]);
			Assert::AreEqual(-1, neighbors[3]);
		}
	};
}