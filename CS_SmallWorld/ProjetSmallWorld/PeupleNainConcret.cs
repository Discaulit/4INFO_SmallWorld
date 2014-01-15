using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    [Serializable()]
    public class PeupleNainConcret : PeupleAbstrait, PeupleNain
    {
        public PeupleNainConcret(JoueurConcret j, BonusCase startCase, int nbUnite)
        {
            for (int i = 0; i < nbUnite; i++)
                fabriqueUnite(j, startCase);
        }

        protected override void fabriqueUnite(JoueurConcret j, BonusCase startCase)
        {
            Unite u = new UniteNainConcret(j, startCase);
            u.Joueur = j;
            j.ajouterUneUnite(u);
        }
    }
}
