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

        protected override int avantageTerrain()
        {
            if (_caseCourante is CaseMontagneConcret)
                return 1;
            else if (_caseCourante is CasePlaineConcret)
                return -1;
            else
                return 0;
        }

        protected override bool deplacementPeuple(BonusCase caseCible)
        {
            // Un nain est capable de se déplacer sur n'importe quelle caseMontagne
            //si est déjà sur une CaseMontagne
            return ((_caseCourante.distance(caseCible) < 2) ||
                (caseCible is CaseMontagne) && (_caseCourante is CaseMontagne));
        }
    }
}
