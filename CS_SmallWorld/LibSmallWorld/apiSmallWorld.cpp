#include "apiSmallWorld.h"

int* generateMap(const int& size)
{
	return Map(size).getMatrice();
}

double calculPtsAtqDefEffectifs(const int& pv, const int& atqOuDef, const int& pvMax)
{
	double perCentPV = pv / pvMax;
	return atqOuDef * perCentPV;
}

double probaAtqGagne(const int& pvAtq, const int& pvDef, const int& atq, const int& def, const int& pvMax)
{
	double Atq = calculPtsAtqDefEffectifs(pvAtq,atq);
	double Def = calculPtsAtqDefEffectifs(pvDef,def);

	double rapportForce = Atq / Def;
	return (0.5*rapportForce);
}