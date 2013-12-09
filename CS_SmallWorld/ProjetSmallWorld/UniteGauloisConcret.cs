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
        /**
         * \fn Constructeur de la classe
         */
        public UniteGauloisConcret(JoueurConcret j, BonusCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;
            _caseCourante.positionnerUnite(this);
        }

        /** cf interface */
        protected override int avantageTerrain()
        {
            if (_caseCourante is CasePlaineConcret)
                return 1;
            else if (_caseCourante is CaseMontagneConcret)
                return -1;
            else
                return 0;
        }
    }
}
