using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class UniteGauloisConcret
     * 
     * \brief Une Unite Gauloise.
     */
    public class UniteGauloisConcret : UniteAbstrait, UniteGaulois
    {
        public UniteGauloisConcret(JoueurConcret j, TypeCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;

        }

        protected override bool avantageTerrain()
        {
            if (_caseCourante is CasePlaineConcret)
                return true;
            else
                return false;
        }
    }
}
