﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseEauConcret : TypeCaseAbstrait, CaseEau
    {
        public override int TypeTerrain
        {
            get { return 3; }
        }
    }
}