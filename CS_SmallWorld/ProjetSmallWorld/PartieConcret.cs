using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CS_SmallWorld
{
    /**
     * \class PartieConcret
     * 
     * \brief implémentation de la classe Partie
     */
    public class PartieConcret : Partie, INotifyPropertyChanged
    {
        List<Joueur> _joueurs;
        Joueur _joueurCourant;
        private int _numJoueurCourant;
        Plateau _plateau;
        MonteurPartie _monteur;
        public static CombatConcret _singletonCombat;
        private int _nbJoueurs;
        private int _nbTourMax;
        private int _numTour;
        private int _tousJoueursOntJoue;

        /**
         * \fn PartieConcret(int taillePlateau, Dictionary<String,int> players)
         * 
         * \brief Constructeur de la classe.
         * 
         */
        public PartieConcret(int taillePlateau, Dictionary<String,int> players)
        {
            _numTour = 0;
            _tousJoueursOntJoue = 0;
            _joueurs = new List<Joueur>();
            _monteur = new MonteurPartieConcret(taillePlateau);
            _plateau = _monteur.Plateau;
            _nbTourMax = _monteur.NbTourMax;
            _singletonCombat = _monteur.singletonCombat();

            int numPlayer = 0;

            foreach (KeyValuePair<String, int> pair in players)
            {
                _joueurs.Add(_monteur.creerJoueur(pair.Key, pair.Value, numPlayer++));
            }
            _nbJoueurs = numPlayer;
            _numJoueurCourant = 0;
            _joueurCourant = _joueurs[_numJoueurCourant];

        }

        /** cf interface */
        public List<Joueur> Joueurs
        {
             get
            {
                return _joueurs;
            }
        }

        /** cf interface */
        public Joueur JoueurCourant
        {
            get
            {
                return _joueurCourant;
            }
            set
            {
                _joueurCourant = value;
                RaisePropertyChanged("JoueurCourant");
            }
        }

        /** cf interface */
        public Plateau Plateau
        {
            get
            {
                return _plateau;
            }
        }

        /* cf interface */
        public bool finirTour()
        {
            _joueurCourant.compterScore();
            foreach (Unite u in _joueurCourant.Troupes)
                u.PtsDeplacement = 2;

            JoueurCourant = _joueurs[++_numJoueurCourant % _nbJoueurs];

            if (Joueurs[0].Troupes.Count == 0 || Joueurs[1].Troupes.Count == 0 || (_tousJoueursOntJoue % _nbJoueurs == 0 && _numTour >= _nbTourMax))
                return false;
            else
            {
                if (++_tousJoueursOntJoue % _nbJoueurs == 0)
                    NumTour++;
                return true;
            }

        }

        /* cf interface */
        public int NbTourMax
        {
            get
            {
                return _nbTourMax;
            }
        }

        /* cf interface */
        public int NumTour
        {
            set
            {
                _numTour = value;
                RaisePropertyChanged("NumTour");
            }
            get
            {
                return _numTour;
            }
        }

        private void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
