﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class UniteVikingConcret : UniteAbstrait, UniteViking
    {
        /**
     * \class UniteVikingConcret
     * 
     * \brief Une Unite Viking.
     */
        public UniteVikingConcret(JoueurConcret j, BonusCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;
            _caseCourante.positionnerUnite(this);
        }

        protected override int avantageTerrain()
        {
            if (_caseCourante is CaseEauConcret)
                return 1;
            else if (_caseCourante is CaseDesertConcret)
                return -1;
            else
                return 0;
        }
    }
}