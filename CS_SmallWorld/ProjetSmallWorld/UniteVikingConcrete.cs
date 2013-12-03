using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class UniteVikingConcret : UniteAbstrait, UniteViking
    {
        public UniteVikingConcret(JoueurConcret j, TypeCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;

        }

        protected override bool avantageTerrain()
        {
            if (_caseCourante.GetType().Name == "CaseEauConcret")
                return true;
            else
                return false;
        }
    }
}
