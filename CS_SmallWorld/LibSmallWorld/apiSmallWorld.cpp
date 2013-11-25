#include "apiSmallWorld.h"

int* generateMap(const int& size)
{
	return Map(size).getMatrice();
}

bool atkWin(const int& pvAtq, const int& pvDef, const int& atq, const int& def,const int &pvMax)
{
	return calculsUtility::AtqGagne(pvAtq, pvDef, atq, def, pvMax);
}