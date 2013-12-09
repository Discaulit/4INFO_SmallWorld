using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class PartieConcret
     * 
     * \brief implémentation de la classe Partie
     */
    public class PartieConcret : Partie
    {
        List<Joueur> _joueurs;
        Joueur _joueurCourant;
        private int _numJoueurCourant;
        Plateau _plateau;
        MonteurPartie _monteur;
        Combat _singletonCombat;
        private int _nbJoueurs;

        /**
         * \fn PartieConcret(int taillePlateau, Dictionary<String,int> players)
         * 
         * \brief Constructeur de la classe.
         * 
         */
        public PartieConcret(int taillePlateau, Dictionary<String,int> players)
        {
            _joueurs = new List<Joueur>();
            _monteur = new MonteurPartieConcret(taillePlateau);
            _plateau = _monteur.Plateau;
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
                throw new NotImplementedException();
            }
        }

        /** cf interface */
        public Joueur JoueurCourant
        {
            get
            {
                return _joueurCourant;
            }
        }

        /** cf interface */
        public Plateau Plateau
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void finirTour()
        {
            _joueurCourant.compterScore();
            _joueurCourant = _joueurs[++_numJoueurCourant % _nbJoueurs];
        }

    }
}
