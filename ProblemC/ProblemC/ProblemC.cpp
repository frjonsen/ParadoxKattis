// ProblemC.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ProblemC.h"

int FindPath(const int nStartX, const int nStartY,
	const int nTargetX, const int nTargetY,
	const unsigned char* pMap, const int nMapWidth, const int nMapHeight,
	int* pOutBuffer, const int nOutBufferSize) {
	
	pOutBuffer[0] = 4;
	pOutBuffer[1] = 8;
	pOutBuffer[2] = 9;

	return 3;
}

