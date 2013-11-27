#include "calculsUtility.h"

double calculsUtility::calculPtsAtqDefEffectifs(const int& pv, const int& atqOuDef, const int& pvMax)
{
	double perCentPV = pv / pvMax;
	return atqOuDef * perCentPV;
}

bool calculsUtility::atqGagneUnTour(const int& pvAtq, const int& pvDef, const int& atq, const int& def, const int& pvMax)
{
	double Atq = calculPtsAtqDefEffectifs(pvAtq,atq);
	double Def = calculPtsAtqDefEffectifs(pvDef,def);

	double rapportForce = Atq / Def;
	return ( (rand()%100) < 100*(0.5*rapportForce) );
}

int calculsUtility::resCombat(const int& pvAtq, const int& pvDef, const int& atq, const int& def, const int& pvMax)
{
	srand(time(0));
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
