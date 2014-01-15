using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    [Serializable()]
    public class CasePlaineConcret : TypeCaseAbstrait, CasePlaine
    {
        public CasePlaineConcret()
        {
            Name = "Plaine";
        }
    }
}
