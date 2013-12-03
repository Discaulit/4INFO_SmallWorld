using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseForetConcret : TypeCaseAbstrait, CaseForet
    {
        public override int TypeTerrain
        {
            get { return 4; }
        }
    }
}
