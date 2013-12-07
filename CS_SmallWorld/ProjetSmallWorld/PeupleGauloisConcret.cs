using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class PeupleGauloisConcret
     * 
     * \brief implémente PeupleAbstrait et PeupleGaulois
     */
    public class PeupleGauloisConcret : PeupleAbstrait, PeupleGaulois
    {
        /**
         * \fn Constructeur de la classe
         */
        public PeupleGauloisConcret(JoueurConcret j, BonusCase startCase, int nbUnite)
        {
            for (int i = 0; i < nbUnite; i++)
                fabriqueUnite(j, startCase);
        }

        /** cf interface */
        protected override void fabriqueUnite(JoueurConcret j, BonusCase startCase)
        {
            Unite u = new UniteGauloisConcret(j, startCase);
            u.Joueur = j;
            j.ajouterUneUnite(u);
        }
    }
}
