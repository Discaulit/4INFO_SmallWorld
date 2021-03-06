﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    [Serializable()]
    public class CaseStandardConcret : BonusCaseAbstrait, CaseStandard
    {
        public CaseStandardConcret(TypeCase tc, Position p)
        {
            _voisines = new List<BonusCase>();
            _position = p;
            _tcase = tc;
            UnitesPresentes = new List<Unite>();
        }
    }
}
