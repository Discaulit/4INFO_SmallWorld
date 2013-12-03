using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class JoueurConcret : Joueur
    {
        private string _name;
        private int _points;
        private Peuple _peuple;
        private List<Unite> _troupes;

        public JoueurConcret(string name, Peuple p, TypeCase startCase)
        {
            _name = name;
            _points = 0;
            _peuple = p;
            _troupes = new List<Unite>();

        }

        public void ajouteUneUnite(Unite u)
        {
            _troupes.Add(u);
        }

        Unite getUneUnite(int numUnite)
        {
            return _troupes.ElementAt(numUnite);
        }
        
        JoueurConcret(string name, Peuple peuple)
        {
            _name = name;
            _peuple = peuple;
            _points = 0;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public Peuple Peuple
        {
            get { return _peuple;}
        }

        public void compterScore()
        {
            int score =0;
            foreach (Unite u in _troupes)
                score += u.PtsGenerer;

            Points += score;
        }
    }
}
