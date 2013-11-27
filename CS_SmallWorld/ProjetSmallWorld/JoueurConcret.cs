using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class JoueurConcret : Joueur
    {
        private int points;
        int Joueur.points
        {
        }

        private Peuple peuple;
        Peuple Joueur.peuple
        {
            get { return peuple;}
            set { peuple = value;}
        }
    }
}
