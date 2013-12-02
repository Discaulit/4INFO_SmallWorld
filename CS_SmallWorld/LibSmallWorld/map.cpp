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
	srand(time(0));

	int type[5];
	int moy = _taille*_taille / 5;

	while (type[0] < (moy-2) && type[0] > (moy+2) &&
		type[1] < (moy-2) && type[1] > (moy+2) &&
		type[2] < (moy-2) && type[2] > (moy+2) &&
		type[3] < (moy-2) && type[3] > (moy+2) &&
		type[4] < (moy-2) && type[4] > (moy+2) )
	{
		for (int i =0; i< _taille*_taille;i++)
		{
			int tmp = typeCase(rand() % 5);
			_matrice[i] = tmp;
			type[tmp]++;
		}
	}
}