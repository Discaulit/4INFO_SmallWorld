using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public abstract class UniteAbstrait : Unite
    {
        private int _ptAtq = 2, _ptDef = 1, _ptVie = 5;
        private int _ptsGenereBase = 1, _ptsAvantageTerrain = 1;

        protected JoueurConcret _joueur;
        protected TypeCase _caseCourante;
       
        public JoueurConcret Joueur
        {
            get { return _joueur; }
            set { _joueur = value; }
        }

        public int PV
        {
            get { return _ptVie; }
            set { _ptVie = value; }
        }

        //Permet de connaitre la position de l'unite
        
        public TypeCase CaseCourante
        {
            get { return _caseCourante; }
            set { _caseCourante = value; }
        }

        public int PtsGenerer
        {
            get { if (avantageTerrain() )
                    return _ptsGenereBase + _ptsAvantageTerrain;
                else
                    return _ptsGenereBase;}
        }

        protected abstract bool avantageTerrain();

        public bool estAmie(Unite u) { return u.Joueur == _joueur; }

        public void deplacer(Case c) { }

        public void detruire() { }

    }
}
