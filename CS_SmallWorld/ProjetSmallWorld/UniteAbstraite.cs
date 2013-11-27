using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public abstract class UniteAbstrait : Unite
    {
        int ptAtq = 2, ptDef = 1, ptVie = 5;
        int posX, posY;

        private Joueur _joueur;
        Joueur Unite.Joueur
        {
            get { return _joueur; }
            set { _joueur = value; }
        }

        private Case _caseCourante;
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
