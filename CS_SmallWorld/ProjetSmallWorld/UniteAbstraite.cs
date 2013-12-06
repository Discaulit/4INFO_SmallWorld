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
        /**
         * points d'attaque et de défense de l'Unite.
         * points que permet de gagner l'Unite de base et le bonus si le Terrain est avantageux.
         */
        protected static int _ptAtq = 3, _ptDef = 2, _ptsGenereBase = 1, _ptsAvantageTerrain = 1;

        /** points de vie et de déplacement de l'Unite */
        protected int _ptVie, _ptsDeplacement;

        /** Le joueur possédant l'Unite */
        protected JoueurConcret _joueur;

        /** La Case sur laquelle se situe l'Unite actuellement */
        protected TypeCase _caseCourante;
        protected Position _position;

        /** cf interface */
        public JoueurConcret Joueur
        {
            get { return _joueur; }
            set { _joueur = value; }
        }

        /** cf interface */
        public TypeCase CaseCourante
        {
            get { return _caseCourante; }
            protected set
            {
                _caseCourante = value;
                _caseCourante.positionnerUnite(this);
            }
        }

        /** cf interface */
        public Position Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        /** cf interface */
        public int PV
        {
            get { return _ptVie; }
            set { _ptVie = value; }
        }

        /** cf interface */
        public int PtsDeplacement
        {
            get { return _ptsDeplacement; }
            set { _ptsDeplacement = value; }
        }

        /** cf interface */
        public int PtsGeneres
        {
            get
            {
                if (avantageTerrain())
                    return _ptsGenereBase + _ptsAvantageTerrain;
                else
                    return _ptsGenereBase;
            }
        }

        /**
         * \fn bool avantageTerrain()
         * 
         * \brief Vérifie si l'Unite est sur une case qui l'avantage.
         * 
         * \return true si l'Unite est sur une case qui l'avantage, faux sinon
         */
        protected abstract bool avantageTerrain();

        /** cf interface */
        public bool estAmie(Unite u) { return u.Joueur == _joueur; }

        /** cf interface */
        public void deplacer(TypeCase c)
        {
            if (_ptsDeplacement > 0)
            {
                _caseCourante.enleverUneUnite(this); //retirer l'Unite de l'ancienne case
                _caseCourante = c; //changer de case
                _caseCourante.positionnerUnite(this); //se rajouter sur la nouvelle case

                if (avantageTerrain())
                    _ptsDeplacement--;
                else
                    _ptsDeplacement -= 2;
            }
            else
                Console.WriteLine("Impossible de bouger\n");
        }


        /**
         * \fn void attaquer(Position cAtq)
         * 
         * \brief Verifie si une case est attaquable ou non, c'est-à-dire si elle est voisine
         * et si elle appartient à l'adversaire. Sinon, se déplacer dessus ou ne indiquer case trop loin.
         * 
         * \param[im] Case cAtq la case attaquée
         */
        public void attaquer(Position cAtq)
        {
            //TODO
        }

        /** cf interface */
        public void detruire()
        {
            //retirer l'Unite de tous les endroits où elle est référencée
            _joueur.retirerUneUnite(this);
            _caseCourante.enleverUneUnite(this);
        }

    }
}
