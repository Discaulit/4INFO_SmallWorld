#pragma once
#include "map.h"
#include "calculsUtility.h"

#ifdef LIBSMALLWORLD_EXPORTS
	#define LIBSMALLWORLD_DLL __declspec(dllexport)
	#define EXTERNC extern "C"
#else
	#define LIBSMALLWORLD_DLL __declspec(dllimport)
	#define EXTERNC
#endif

double calculPtsAtqDefEffectifs(const int& pv, const int& atqOuDef, const int& pvMax=5);

//LIBSMALLWORLD_DLL Map::typeCase;

EXTERNC LIBSMALLWORLD_DLL int* generateMap(const int size);

EXTERNC LIBSMALLWORLD_DLL bool atkWin(const int& pvAtq, const int& pvDef, const int& atq=2, const int& def=1,const int &pvMax=5);

