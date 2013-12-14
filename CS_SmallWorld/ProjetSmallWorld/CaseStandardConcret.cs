using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseStandardConcret : BonusCaseAbstrait, CaseStandard
    {
        private List<Unite> _troupes;
        public CaseStandardConcret(TypeCase tc, Position p)
        {
            _position = p;
            _tcase = tc;
            _troupes = new List<Unite>();
        }
    }
}
