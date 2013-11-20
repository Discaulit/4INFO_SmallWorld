// Il s'agit du fichier DLL principal.

#include "stdafx.h"

#include "wrapperLibSmallWorld.h"

wrapperLibSmallWorld::WrapperLibsSmallWorld(int taille)
{
	_map = new List<int>();
	int* map = generateMap(taille);
	for(int i = 0; i < taille*taille; i++)
		_map->add(map[i]);
}

