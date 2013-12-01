using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class JoueurConcret : Joueur
    {
        private int _points;
        private string _name;
        private Peuple _peuple;
        protected List<Unite> _troupes;

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
