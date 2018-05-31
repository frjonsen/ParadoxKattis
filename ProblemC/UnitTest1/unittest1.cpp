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
			unsigned char pMap[] = { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1 };
			int pOutBuffer[12];
			auto res = FindPath(0, 0, 1, 2, pMap, 4, 3, pOutBuffer, 12);
			Assert::AreEqual(-1, res);
		}
	};
}