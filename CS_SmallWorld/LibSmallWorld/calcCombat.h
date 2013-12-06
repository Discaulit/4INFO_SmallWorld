#pragma once
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */

class CalcCombat
{
public:
	CalcCombat();
	/**
	*	\fn int combatResult(const int pvAtq, const int pvDef, const int atq = 3, const int def = 2, const int pvMax = 5)
	*
	*	\brief Indique si l'attaquant gagne ou non ce combat.
	*
	*	\return les pv de l'Atq en dizaine, pv de la Def en unite.
	*/
	int resCombat(const int pvAtq, const int pvDef, const int atq = 4, const int def = 3, const int pvMax = 5);
	
private:
	/**
	*	\fn bool atqGagneUnTour(const int pvAtq, const int pvDef, const int atq = 3, const int def = 2, const int pvMax = 5)
	*
	*	\brief Indique si l'attaquant gagne ou non ce tour.
	*
	*	\return true si l'attaquant gagne ce tour, false sinon.
	*/
	bool atqGagneUnTour(const int pvAtq, const int pvDef, const int atq = 4, const int def = 3, const int pvMax = 5);

	/**
	*	\fn double calculPtsAtqDefEffectifs(const int& pv, const int& atqOuDef, const int& pvMax = 5)
	*
	*	\brief calcul l'attaque ou la defense effective d'une unite en fonction de son pourcentage de vie restant.
	*
	*	\return l'attaque ou la defense effective d'une unite.
	*/
	double calculPtsAtqDefEffectifs(const int pv, const int atqOuDef, const int pvMax = 5);
};

