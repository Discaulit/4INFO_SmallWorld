using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseDesertConcret : TypeCaseAbstrait, CaseDesert
    {
        public override typeCase TypeTerrain
        {
            get { return typeCase.t_desert; }
        }
    }
}
