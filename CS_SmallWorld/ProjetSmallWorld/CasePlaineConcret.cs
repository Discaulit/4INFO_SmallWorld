using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CasePlaineConcret : TypeCaseAbstrait, CasePlaine
    {
        public CasePlaineConcret()
        {
            _unitePresente = new List<Unite>();
        }
    }
}
