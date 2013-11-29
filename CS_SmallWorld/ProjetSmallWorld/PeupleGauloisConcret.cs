using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class PeupleGauloisConcret : PeupleAbstrait, PeupleGaulois
    {
        PeupleGauloisConcret(JoueurConcret j, int nbUnite)
        {
            for (int i = 0; i < nbUnite; i++)
                fabriqueUnite(j);
        }

        protected override void fabriqueUnite(JoueurConcret j)
        {
            UniteGauloisConcret u = new UniteGauloisConcret();
            u.Joueur = j;
            
            _troupes.Add(u);
        }
    }
}
