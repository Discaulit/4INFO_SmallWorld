using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;

namespace CS_SmallWorld
{
    public class CaseEauConcret : TypeCaseAbstrait, CaseEau
    {
        public CaseEauConcret()
        {
            Name = "Eau";
        }
    }
}
