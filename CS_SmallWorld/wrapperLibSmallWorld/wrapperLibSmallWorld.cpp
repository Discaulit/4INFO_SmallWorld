// Il s'agit du fichier DLL principal.

#include "stdafx.h"

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

