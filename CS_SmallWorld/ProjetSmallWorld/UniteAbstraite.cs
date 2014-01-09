using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CS_SmallWorld
{
    /**
     * \class UniteAbstraite
     * 
     * \brief implémente en partie Unite : possède les fonctions et attributs communs à toutes les Unites
     */
    public abstract class UniteAbstrait : Unite, INotifyPropertyChanged
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
        public int PV
        {
            get { return _ptVie; }
            set 
            { 
                _ptVie = value;
                RaisePropertyChanged("PV");
            }
        }

        /** cf interface */
        public int PtsDeplacement
        {
            get { return _ptsDeplacement; }
            set 
            {
                _ptsDeplacement = value;
                RaisePropertyChanged("PV");
            }
        }

        /** cf interface */
        public int PtsGeneres
        {
            get
            {
                if (!_caseCourante.PointsGeneres)
                {
                    _caseCourante.PointsGeneres = true;
                    if (_caseCourante is CaseEauConcret)
                        return 0; //une case Eau ne donne jamais de points
                    else if (avantageTerrain() == 0) //case standard
                        return _ptsGenereBase;
                    else if (avantageTerrain() == 1) // avantage
                        return _ptsGenereBase + _ptsAvantageTerrain;
                    else // desavantage
                        return _ptsGenereBase - _ptsAvantageTerrain;
                }
                else
                    return 0;
            }
        }

        /** cf interface */
        public bool estAmie(Unite u) { return u.Joueur == _joueur; }

        /** cf interface */
        public bool utiliserUnite(BonusCase c)
        {
            if (caseAccessible(c))
            {
                //se deplacer si la case est alliée ou vide
                if ( (c.getMeilleureUnite() == null) || estAmie(c.getMeilleureUnite()))
                {
                    deplacer(c);
                    return true;
                }
                else //sinon attaquer
                {
                    return attaquer(c);
                }
            }
            else
                return false;
        }

        /**
         * \fn int avantageTerrain()
         * 
         * \brief Vérifie si l'Unite est sur une case qui l'avantage.
         * 
         * \return 1 si l'Unite est sur une case qui l'avantage, 0 si c'est une case neutre, -1 sinon
         */
        protected abstract int avantageTerrain();

        /**
         * \fn void deplacementOk(BonusCase caseCible)
         * 
         * \brief Vérifie si l'Unite peut se déplacer sur la case passée en paramètre.
         *
         * \param[in] BonusCase c la case cible
         * 
         * \return true si l'Unite est capable de se déplacer à cet endroit, false sinon
         */
        protected bool caseAccessible(BonusCase caseCible)
        {
            // test d'abord si c'est une Unite Viking car celle-ci peut aller sur l'eau ;
            // si ce n'est pas une Unite Viking, elle n'a pas le droit.
            if ((this is UniteViking) || !(caseCible.TCase is CaseEau))
            {
                if (_ptsDeplacement > 0)
                {
                    return deplacementPeuple(caseCible);
                }
                else
                    return false;
            }
            else // impossible d'aller sur une case Eau si Unite non Viking
                return false;
        }

        /**
         * \fn bool deplacementPeuple(BonusCase caseCible)
         * 
         * \brief la partie de déplacement propre au Peuple par rapport aux bonus.
         * 
         * \param[in] la case cible du déplacement
         * 
         * \return true si le déplacement est possible, false sinon
         */
        protected abstract bool deplacementPeuple(BonusCase caseCible);

        /**
         * \fn void deplacer(BonusCase c)
         * 
         * \brief Déplace l'Unite sur la case passée en paramètre.
         * 
         * \param[in] BonusCase c la case cible
         */
        private void deplacer(BonusCase c)
        {
            _caseCourante.enleverUneUnite(this); //retirer l'Unite de l'ancienne case
            _caseCourante = c; //changer de case
            _caseCourante.positionnerUnite(this); //se rajouter sur la nouvelle case
            if (this is UniteGaulois && _caseCourante is CasePlaine && _caseCourante.distance(c) == 1)
                PtsDeplacement--; // Le Gaulois peut se déplacer 2x s'il est une case Plaine lors de son 1er déplacement
            else
                PtsDeplacement -= 2;
        }

        /**
         * \fn void attaquer(BonusCase cAtq)
         * 
         * \brief Verifie si une case est attaquable ou non, c'est-à-dire si elle est voisine
         * et si elle appartient à l'adversaire. Sinon, se déplacer dessus ou ne indiquer case trop loin.
         * 
         * \param[im] Case cAtq la case attaquée
         */
        private bool attaquer(BonusCase cAtq)
        {
            //TODO: faire le combat
            PartieConcret._singletonCombat.lancerCombat(this, cAtq);
            //action en fonction du résultat du combat :
            if (PV == 0)
            {
                detruire();
                return false;
            }
            else
            {
                Unite uDef = cAtq.getMeilleureUnite();
                if (uDef.PV == 0)
                    uDef.detruire();

                if (cAtq.getMeilleureUnite() == null)
                {
                    deplacer(cAtq);
                    return true;
                }
                else
                    return false;
            }
        }

        /** cf interface */
        public void detruire()
        {
            //retirer l'Unite de tous les endroits où elle est référencée
            _joueur.retirerUneUnite(this);
            _caseCourante.enleverUneUnite(this);
        }

        private void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
