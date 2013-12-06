using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseForetConcret : TypeCaseAbstrait, CaseForet
    {
        public CaseForetConcret()
        {
            _pos = new Position(-1, -1); //case non positionnée
            _unitePresente = new List<Unite>();
        }
    }
}
