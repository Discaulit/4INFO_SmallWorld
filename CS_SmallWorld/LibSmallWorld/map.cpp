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

int* Map::getPositionsDepart(const int taille)
{
	int* posDepart = new int[4];

	do{
		posDepart[0] = rand() % taille; //x1
		posDepart[1] = rand() % taille; //y1
		posDepart[2] = rand() % taille; //x2
		posDepart[3] = rand() % taille; //y2

		//abs(x1-x2) + abs(y1-y2) = distance entre les deux positions
	}while( (abs(posDepart[0]-posDepart[2]) + abs(posDepart[1]-posDepart[3])) > _taille);


	return posDepart;
}