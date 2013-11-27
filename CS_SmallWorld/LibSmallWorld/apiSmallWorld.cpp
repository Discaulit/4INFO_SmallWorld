#include "apiSmallWorld.h"

int* generateMap(const int& size)
{
	return Map(size).getMatrice();
}

int resCombat(const int& pvAtq, const int& pvDef, const int& atq, const int& def,const int &pvMax)
{
	return calculsUtility::resCombat(pvAtq, pvDef, atq, def, pvMax);
}