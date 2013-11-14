#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */
class Map
{
	enum typeCase{ t_montagne, t_plaine, t_desert, t_eau, t_foret};

private:
	int _taille;
	int* _matrice;

public:
	Map(int taille);
	~Map(void);

	inline int* getMatrice() {return _matrice;}
	inline int getTaille() {return _taille;}

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

