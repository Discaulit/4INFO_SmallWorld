// wrapperLibSmallWorld.h
#pragma once

//#pragma comment (lib,"../debug/LibSmallWorld.lib")

#include "apiSmallWorld.h"

using namespace System;
using namespace System::Collections::Generic;

namespace wrapperLibSmallWorld {

	[Serializable]
	public ref class WrapperLibsSmallWorld
	{
	private :
		List<int>^ _map;

	public:
		WrapperLibsSmallWorld(const int size);
		inline List<int>^ getMap() {return _map;}
		
		List<int>^ combatResult(const int pvAtq, const int pvDef, const int atq, const int def,const int pvMax);

		inline List<int>^ getStartCases(const int size);

	};
}