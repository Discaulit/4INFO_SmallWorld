﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CasePlaineConcret : TypeCaseAbstrait, CasePlaine
    {
        public override int TypeTerrain
        {
            get { return 1; }
        }
    }
}
