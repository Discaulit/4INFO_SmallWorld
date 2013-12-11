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
        protected const int _ptAtq = 3, _ptDef = 2, _ptsGenereBase = 1, _ptsAvantageTerrain = 1;

        /** points de vie et de déplacement de l'Unite */
        protected int _ptVie, _ptsDeplacement;

        /** Le joueur possédant l'Unite */
        protected JoueurConcret _joueur;

        /** La Case sur laquelle se situe l'Unite actuellement */
        public BonusCase _caseCourante;

        /** cf interface */
        public JoueurConcret Joueur
        {
            get { return _joueur; }
            set { _joueur = value; }
        }

        /** cf interface */
        public BonusCase CaseCourante
        {
            get { return _caseCourante; }
            protected set
            {
                _caseCourante = value;
                _caseCourante.positionnerUnite(this);
            }
        }

        /** cf interface */
        //public Position Position
        //{
        //    get { return _position; }
        //    set
        //    {
        //        _position = value;
        //    }
        //}

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
                if (avantageTerrain() == 0) //case standard
                    return _ptsGenereBase;
                else if (avantageTerrain() == 1) // avantage
                    return _ptsGenereBase + _ptsAvantageTerrain;
                else // desavantage
                    return _ptsGenereBase - _ptsAvantageTerrain;
            }
        }

        protected abstract int avantageTerrain();

        /**
         * \fn int avantageDeplacementTerrain()
         * 
         * \brief Vérifie si l'Unite est sur une case qui l'avantage.
         * 
         * \return 1 si l'Unite est sur une case qui l'avantage, 0 si c'est une case neutre, -1 sinon
         */
        //protected abstract bool avantageDeplacementTerrain();

        /**
         * \fn void deplacerPeuple()
         * 
         * \brief La partie du déplacement spécifique au Peuple de l'Unite, par rapport aux différents bonus.
         */
        //protected abstract void deplacerPeuple();

        /** cf interface */
        public bool estAmie(Unite u) { return u.Joueur == _joueur; }

        /** cf interface */
        public void utiliserUnite(BonusCase c)
        {
            //se deplacer si la case est alliée ou vide
            if (estAmie(c.getMeilleureUnite()) || (c.getMeilleureUnite() == null))
                deplacer(c);
            else //sinon attaquer
                attaquer(c);
        }

        /**
         * \fn void deplacer(BonusCase c)
         * 
         * \brief Déplace l'Unite sur la case passée en paramètre.
         * 
         * \param[in] BonusCase c la case cible
         */
        private void deplacer(BonusCase c)
        {
            if (_ptsDeplacement > 0)
            {
                _caseCourante.enleverUneUnite(this); //retirer l'Unite de l'ancienne case
                _caseCourante = c; //changer de case
                _caseCourante.positionnerUnite(this); //se rajouter sur la nouvelle case

                //deplacerPeuple();
            }
            else
                Console.WriteLine("Impossible de bouger\n");
        }


        /**
         * \fn void attaquer(BonusCase cAtq)
         * 
         * \brief Verifie si une case est attaquable ou non, c'est-à-dire si elle est voisine
         * et si elle appartient à l'adversaire. Sinon, se déplacer dessus ou ne indiquer case trop loin.
         * 
         * \param[im] Case cAtq la case attaquée
         */
        private void attaquer(BonusCase cAtq)
        {
            //TODO: faire le combat

            //action en fonction du résultat du combat :
            if (PV == 0)
                detruire();
            else
                if (cAtq.getMeilleureUnite() == null)
                    deplacer(cAtq);

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
