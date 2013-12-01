using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class PeupleNainConcret : PeupleAbstrait, PeupleNain
    {
        PeupleNainConcret(JoueurConcret j, int nbUnite)
        {
            for (int i = 0; i < nbUnite; i++)
                fabriqueUnite(j);
        }

        protected override void fabriqueUnite(JoueurConcret j)
        {
            Unite u = new UniteNainConcret();
            u.Joueur = j;
            j.ajouteUneUnite(u);
        }
    }
}
