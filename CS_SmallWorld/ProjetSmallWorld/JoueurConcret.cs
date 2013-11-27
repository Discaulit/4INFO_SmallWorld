using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class JoueurConcret : Joueur
    {
        private int _points;
        int Joueur.points
        {
            get { return _points; }
            set { _points = value; }
        }

        private Peuple _peuple;
        Peuple Joueur.peuple
        {
            get { return _peuple;}
            set { _peuple = value;}
        }
    }
}
