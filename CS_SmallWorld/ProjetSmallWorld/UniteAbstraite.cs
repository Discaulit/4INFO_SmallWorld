using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class UniteAbstraite
     * 
     * \brief implémente en partie Unite : possède les fonctions et attributs communs à toutes les Unites
     */
    public abstract class UniteAbstrait : Unite
    {
        protected static int _ptAtq = 4, _ptDef = 3, _ptsGenereBase = 1, _ptsAvantageTerrain = 1; 
        protected int _ptVie, _ptsDeplacement;

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

        public TypeCase CaseCourante
        {
            get { return _caseCourante; }
            set
            {
                _caseCourante = value;
                _caseCourante.positionnerUnite(this);
            }
        }

        public int PtsGeneres
        {
            get { if (avantageTerrain() )
                    return _ptsGenereBase + _ptsAvantageTerrain;
                else
                    return _ptsGenereBase;}
        }

        public int PtsDeplacement
        {
            get { return _ptsDeplacement; }
            set { _ptsDeplacement = value; }
        }

        /**
         * \fn bool avantageTerrain()
         * 
         * \brief Vérifie si l'Unite est sur une case qui l'avantage.
         * 
         * \return true si l'Unite est sur une case qui l'avantage, faux sinon
         */
        protected abstract bool avantageTerrain();

        public bool estAmie(Unite u) { return u.Joueur == _joueur; }

        public void deplacer(TypeCase c)
        {
            _caseCourante.enleverUneUnite(this); //retirer l'Unite de l'ancienne case
            _caseCourante = c; //changer de case
            _caseCourante.positionnerUnite(this); //se rajouter sur la nouvelle case
        }

        public void detruire()
        {
            //retirer l'Unite de tous les endroits où elle est référencée
            _joueur.retirerUneUnite(this);
            _caseCourante.enleverUneUnite(this);
        }

    }
}
