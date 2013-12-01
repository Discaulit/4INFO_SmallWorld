using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public enum typeCase { t_montagne = 0, t_plaine, t_desert, t_eau, t_foret };

    public abstract class TypeCaseAbstrait : CaseAbstrait, TypeCase
    {
        public abstract typeCase TypeTerrain
        { 
            get;
        }
    }

}
