using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class PeupleVikingConcret : PeupleAbstrait, PeupleViking
    {
        PeupleVikingConcret(JoueurConcret j, int nbUnite)
        {
            for (int i = 0; i < nbUnite; i++)
                fabriqueUnite(j);
        }

        protected override void fabriqueUnite(JoueurConcret j)
        {
            Unite u = new UniteVikingConcret();
            u.Joueur = j;
            j.ajouteUneUnite(u);
        }
    }
}
