#include "apiSmallWorld.h"

int* generateMap(const int& size)
{
	Map* map = new Map(size);
	return map->getMatrice();
}

int resCombat(const int& pvAtq, const int& pvDef, const int& atq, const int& def,const int &pvMax)
{
	return calculsUtility::resCombat(pvAtq, pvDef, atq, def, pvMax);
}