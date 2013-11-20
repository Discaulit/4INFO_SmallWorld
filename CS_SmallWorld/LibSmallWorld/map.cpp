#include "map.h"


Map::Map(int taille)
{
	_matrice = new int[taille*taille];
	_taille = taille;
	typerCase();
}


Map::~Map(void)
{
	freeMatrice();
}

void Map::freeMatrice()
{
	delete[] _matrice;
}

void Map::typerCase()
{
	bool type[5] = {false,false,false,false,false}; 
	
	while(!type[0] && !type[1] && !type[2] && !type[3] && !type[4])
	{
		for (int i =0; i< _taille*_taille;i++)
		{
			int tmp = typeCase(rand() % 5);
			_matrice[i] = tmp;
			type[tmp] = true;
		}
	}
}