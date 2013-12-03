using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseMontagneConcret : TypeCaseAbstrait, CaseMontagne
    {
        public override int TypeTerrain
        {
            get { return 0; }
        }
    }
}
