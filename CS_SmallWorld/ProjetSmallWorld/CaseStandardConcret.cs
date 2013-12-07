using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseStandardConcret : BonusCaseAbstrait, CaseStandard
    {
        public CaseStandardConcret(Position p, TypeCase tc)
        {
            _position = p;
            _tcase = tc;
        }
    }
}
