#include "calcCombat.h"
#include <math.h>

CalcCombat::CalcCombat()
{
	srand(time(0));
}

double CalcCombat::calculPtsAtqDefEffectifs(const int pv, const int atqOuDef, const int pvMax)
{
	double perCentPV = pv / pvMax;
	return atqOuDef * perCentPV;
}

bool CalcCombat::atqGagneUnTour(const int pvAtq, const int pvDef, const int atq, const int def, const int pvMax)
{
	double Atq = calculPtsAtqDefEffectifs(pvAtq,atq);
	double Def = calculPtsAtqDefEffectifs(pvDef,def);

	double maxAtqDef = (Atq>Def)?Atq:Def;
	//double rapportForce = Atq / Def; // Calcul standard du poly
	double rapportForce = 1+ ((Atq-Def)/maxAtqDef); //Calcul légèrement modifié

	return ( (rand()%100) < 100*(0.5*rapportForce) );
}

int CalcCombat::resCombat(const int pvAtq, const int pvDef, const int atq, const int def, const int pvMax)
{
	int res = pvAtq*10 + pvDef; // dizaine = pvAtq, unite = pvDef
	int supPv = (pvAtq<pvDef)?pvDef:pvAtq;
	int nbTour = (rand() % supPv) +3;

	while(nbTour >0 && (res/10 > 0) && (res% 10 > 0) ){ // Test sur nbTour, pvAtq et pvDef
		if(atqGagneUnTour(pvAtq,pvDef) )
			res--;
		else
			res-=10;

		nbTour--;
	}

	return res;

}
