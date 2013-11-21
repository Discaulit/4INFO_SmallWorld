#pragma once
#include "map.h"

#ifdef LIBSMALLWORLD_EXPORTS
	#define LIBSMALLWORLD_DLL __declspec(dllexport)
#else
	#define LIBSMALLWORLD_DLL __declspec(dllimport)
#endif

extern "C" {
	//LIBSMALLWORLD_DLL Map::typeCase;

	double calculPtsAtqDefEffectifs(const int& pv, const int& atqOuDef, const int& pvMax=5);

	LIBSMALLWORLD_DLL int* generateMap(const int size);

	LIBSMALLWORLD_DLL double probaAtqGagne(const int& pvAtq, const int& pvDef, const int& atq=2, const int& def=1,const int &pvMax=5);
}

