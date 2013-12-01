using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class UniteVikingConcret : UniteAbstrait, UniteViking
    {
        protected override bool avantageTerrain()
        {
            if (_caseCourante.TypeTerrain == typeCase.t_eau)
                return true;
            else
                return false;
        }
    }
}
