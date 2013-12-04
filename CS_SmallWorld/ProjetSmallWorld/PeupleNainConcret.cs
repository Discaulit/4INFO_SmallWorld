using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class PeupleNainConcret : PeupleAbstrait, PeupleNain
    {
        public PeupleNainConcret(JoueurConcret j, TypeCase startCase, int nbUnite)
        {
            for (int i = 0; i < nbUnite; i++)
                fabriqueUnite(j, startCase);
        }

        protected override void fabriqueUnite(JoueurConcret j, TypeCase startCase)
        {
            Unite u = new UniteNainConcret(j, startCase);
            u.Joueur = j;
            j.ajouteUneUnite(u);
        }
    }
}
