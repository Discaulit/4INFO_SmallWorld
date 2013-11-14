#pragma once

#include "map.h"

#ifdef LIBSMALLWORLD_EXPORTS;

	#define LIBSMALLWORLD_DLL __declspec(dllexport)
#else
	#define LIBSMALLWORLD_DLL __declspec(dllimport)
#endif

extern "C" {
	LIBSMALLWORLD_DLL int* generateMap(int size);
}

