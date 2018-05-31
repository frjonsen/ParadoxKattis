#include "stdafx.h"
#include "CppUnitTest.h"
#include "../ProblemC/ProblemC.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{
	TEST_CLASS(UnitTest1)
	{
	public:

		TEST_METHOD(Paradox1)
		{
			unsigned char pMap[] = { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1 };
			int pOutBuffer[12];
			auto res = FindPath(0, 0, 1, 2, pMap, 4, 3, pOutBuffer, 12);
			Assert::AreEqual(3, res);
			Assert::AreEqual(1, pOutBuffer[0]);
			Assert::AreEqual(5, pOutBuffer[1]);
			Assert::AreEqual(9, pOutBuffer[2]);
		}

		TEST_METHOD(Paradox2)
		{
			unsigned char pMap[] = { 0, 0, 1, 0, 1, 1, 1, 0, 1 };
			int pOutBuffer[7];
			FindPath(2, 0, 0, 2, pMap, 3, 3, pOutBuffer, 7);
		}

		TEST_METHOD(Minimal)
		{
			unsigned char pMap[] = { 1, 1 };
			int pOutBuffer[12];
			auto res = FindPath(0, 0, 1, 0, pMap, 2, 1, pOutBuffer, 12);
			Assert::AreEqual(1, res);
			Assert::AreEqual(1, pOutBuffer[0]);
		}

		TEST_METHOD(DeadEnd) {
			unsigned char pMap[] = {
				'1', '1', '1', '1', '1',
				'0', '1', '1', '0', '1',
				'0', '1', '1', '0', '1',
				'0', '0', '0', '0', '1',
				'1', '1', '1', '1', '1'
			};
			int pOutBuffer[12];
			auto res = FindPath(0, 0, 0, 4, pMap, 5, 5, pOutBuffer, 12);
			Assert::AreEqual(12, res);
		}

		TEST_METHOD(MiddleOut) {
			unsigned char pMap[] = {
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
			};

			int pOutBuffer[12];
			auto res = FindPath(2, 4, 2, 0, pMap, 5, 6, pOutBuffer, 12);
			Assert::AreEqual(4, res);
		}

		TEST_METHOD(GoingAround) {
			unsigned char pMap[] = {
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'0', '0', '0', '0', '1',
				'1', '1', '1', '1', '1',
			};

			int pOutBuffer[13];
			auto res = FindPath(0, 0, 0, 5, pMap, 5, 6, pOutBuffer, 13);
			Assert::AreEqual(13, res);
		}

		TEST_METHOD(MiddleOut2) {
			unsigned char pMap[] = {
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
			};

			int pOutBuffer[12];
			auto res = FindPath(4, 3, 2, 0, pMap, 5, 5, pOutBuffer, 12);
			Assert::AreEqual(5, res);
		}


		TEST_METHOD(Obstacle) {
			unsigned char pMap[] = {
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '0', '0', '0', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
				'1', '1', '1', '1', '1',
			};

			int pOutBuffer[12];
			auto res = FindPath(2, 4, 2, 0, pMap, 5, 5, pOutBuffer, 12);
			Assert::AreEqual(8, res);
		}
	};
}