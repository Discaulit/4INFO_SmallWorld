using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public abstract class UniteAbstrait : Unite
    {
        private int _ptAtq = 2, _ptDef = 1, _ptVie = 5;

        JoueurConcret _joueur;
        private Case _caseCourante;

       
        JoueurConcret Unite.Joueur
        {
            get { return _joueur; }
            set { _joueur = value; }
        }

        //Permet de connaitre la position de l'unite
        
        Case Unite.CaseCourante
        {
            get { return _caseCourante; }
            set { _caseCourante = value; }
        }

        bool Unite.estAmie(Unite u) { return u.Joueur == _joueur; }

        void Unite.deplacer(Case c) { }

        void Unite.detruire() { }

    }
}
