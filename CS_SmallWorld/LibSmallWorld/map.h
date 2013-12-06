#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */
class Map
{

private:
	int _taille;
	int* _matrice;

public:
	Map(const int taille);
	~Map(void);

	int* getMatrice() {return _matrice;}
	int getTaille() {return _taille;}

private:
	/**
	* \fn void freeMatrice()
	* \brief detruit la matrice
	*/
	void freeMatrice();

	/**
	* \fn void typerCase()
	* \brief definie le type de terrain de chaque case de la carte
	*/
	void typerCase();
	//void placerPouvoirCase();

};

