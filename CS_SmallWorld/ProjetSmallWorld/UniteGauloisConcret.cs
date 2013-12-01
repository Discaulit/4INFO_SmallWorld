using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class UniteGauloisConcret : UniteAbstrait, UniteGaulois
    {
        protected override bool avantageTerrain()
        {
            if (_caseCourante.TypeTerrain == typeCase.t_plaine)
                return true;
            else
                return false;
        }
    }
}
