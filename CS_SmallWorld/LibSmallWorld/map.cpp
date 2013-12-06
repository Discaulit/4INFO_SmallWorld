#include "map.h"


Map::Map(const int taille)
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
	srand(time(0));

	int type[5] = {0,0,0,0,0};
	int moy = _taille*_taille / 5;

	for (int i =0; i< _taille*_taille;i++)
	{
		int tmp =0;
		do{
			tmp = rand() % 5;
		}while(type[tmp] >= moy);
		
		_matrice[i] = tmp;
		type[tmp]++;
	}
}