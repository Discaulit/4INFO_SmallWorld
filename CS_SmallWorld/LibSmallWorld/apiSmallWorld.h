#pragma once
#include "map.h"
#include "calcCombat.h"

#define LIBSMALLWORLD_EXPORTS
#ifdef LIBSMALLWORLD_EXPORTS
	#define LIBSMALLWORLD_DLL __declspec(dllexport)
	//#define EXTERNC extern "C"
	#define EXTERNC  
#else
	#define LIBSMALLWORLD_DLL __declspec(dllimport)
	#define EXTERNC
#endif

EXTERNC LIBSMALLWORLD_DLL int* generateMap(const int size);

/*
Fait combattre deux unitées et
retourne leurs points de vie (attaquante en dizaine, défensive en unité) à la fin de ce combat.
*/
EXTERNC LIBSMALLWORLD_DLL int resCombat(const int pvAtq, const int pvDef, const int atq=4, const int def=3,const int pvMax=5);

