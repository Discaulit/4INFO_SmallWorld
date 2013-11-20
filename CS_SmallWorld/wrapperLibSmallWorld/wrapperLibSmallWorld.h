// wrapperLibSmallWorld.h
#pragma once

//#pragma comment (lib,"../debug/LibSmallWorld.lib")

#include "apiSmallWorld.h"

using namespace System;
using namespace System::Collections::Generic;

namespace wrapperLibSmallWorld {

	public ref class WrapperLibsSmallWorld
	{
	private :
		List<int>^ _map;

	public:
		WrapperLibsSmallWorld(int taille);
		inline List<int>^ getMap() {return _map;}
	};
}