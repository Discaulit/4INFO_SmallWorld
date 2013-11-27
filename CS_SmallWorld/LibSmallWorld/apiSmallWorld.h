#pragma once
#include "map.h"
#include "calculsUtility.h"

#define LIBSMALLWORLD_EXPORTS
#ifdef LIBSMALLWORLD_EXPORTS
	#define LIBSMALLWORLD_DLL __declspec(dllexport)
	//#define EXTERNC extern "C"
	#define EXTERNC  
#else
	#define LIBSMALLWORLD_DLL __declspec(dllimport)
	#define EXTERNC
#endif

EXTERNC LIBSMALLWORLD_DLL double calculPtsAtqDefEffectifs(const int& pv, const int& atqOuDef, const int& pvMax=5);

//LIBSMALLWORLD_DLL Map::typeCase;

EXTERNC LIBSMALLWORLD_DLL int* generateMap(const int& size);

EXTERNC LIBSMALLWORLD_DLL int resCombat(const int& pvAtq, const int& pvDef, const int& atq=2, const int& def=1,const int &pvMax=5);

