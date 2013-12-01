using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseEauConcret : TypeCaseAbstrait, CaseEau
    {
        public override typeCase TypeTerrain
        {
            get { return typeCase.t_eau; }
        }
    }
}
