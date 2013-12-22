using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseStandardConcret : BonusCaseAbstrait, CaseStandard
    {
        public CaseStandardConcret(TypeCase tc, Position p)
        {
            _position = p;
            _tcase = tc;
            _unitesPresentes = new List<Unite>();
        }
    }
}
