using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class UniteNainConcret : UniteAbstrait, UniteNain
    {
        public UniteNainConcret(JoueurConcret j, TypeCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;

        }

        protected override bool avantageTerrain()
        {
            if (_caseCourante.GetType().Name == "CaseMontagneConcret")
                return true;
            else
                return false;
        }
    }
}
