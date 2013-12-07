﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class UniteNainConcret
     * 
     * \brief Une Unite Naine.
     */
    public class UniteNainConcret : UniteAbstrait, UniteNain
    {
        public UniteNainConcret(JoueurConcret j, BonusCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;
            _caseCourante.positionnerUnite(this);
        }

        protected override bool avantageTerrain()
        {
            if (_caseCourante is CaseMontagneConcret)
                return true;
            else
                return false;
        }
    }
}
