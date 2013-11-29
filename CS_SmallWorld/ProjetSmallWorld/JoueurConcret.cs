using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class JoueurConcret : Joueur
    {
        JoueurConcret(string name, Peuple peuple)
        {
            _name = name;
            _peuple = peuple;
            _points = 0;
        }

        private string _name;
        string Joueur.Name
        {
            get { return _name; }
        }

        private int _points;
        int Joueur.Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private Peuple _peuple;
        Peuple Joueur.Peuple
        {
            get { return _peuple;}
        }

        private List<Unite> _troupes;

    }
}
