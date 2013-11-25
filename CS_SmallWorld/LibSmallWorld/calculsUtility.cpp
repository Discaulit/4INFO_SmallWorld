#include "calculsUtility.h"

double calculsUtility::calculPtsAtqDefEffectifs(const int& pv, const int& atqOuDef, const int& pvMax)
{
	double perCentPV = pv / pvMax;
	return atqOuDef * perCentPV;
}

bool calculsUtility::AtqGagne(const int& pvAtq, const int& pvDef, const int& atq, const int& def, const int& pvMax)
{
	double Atq = calculPtsAtqDefEffectifs(pvAtq,atq);
	double Def = calculPtsAtqDefEffectifs(pvDef,def);

	double rapportForce = Atq / Def;
	return ( (rand()%100) < 100*(0.5*rapportForce) );
}
