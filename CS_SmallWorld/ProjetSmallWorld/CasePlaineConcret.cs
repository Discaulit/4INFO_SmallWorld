using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CasePlaineConcret : TypeCaseAbstrait, CasePlaine
    {
        public override typeCase TypeTerrain
        {
            get { return typeCase.t_plaine; }
        }
    }
}
