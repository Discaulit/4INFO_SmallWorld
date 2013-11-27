// Il s'agit du fichier DLL principal.

//#include "stdafx.h"

#include "wrapperLibSmallWorld.h"

//le wrapper etant enveloppe dans le namespace, il est utile pour de faire ce using
using namespace wrapperLibSmallWorld;

WrapperLibsSmallWorld::WrapperLibsSmallWorld(int taille)
{
	_map = gcnew List<int>(); //gcnew pour les classes managees
	int* map = generateMap(taille);
	for(int i = 0; i < taille*taille; i++)
		_map->Add(map[i]);
}

List<int>^ WrapperLibsSmallWorld::combatResult(const int& pvAtq, const int& pvDef, const int& atq, const int& def,const int &pvMax)
	{
		int res = resCombat(pvAtq,pvDef,atq,def,pvMax);
		List<int>^ lRes = gcnew  List<int>();
		lRes->Add(res/10); // pvAtq
		lRes->Add(res%10); // pvDef
		return lRes;
	}
