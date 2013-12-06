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
        List<JoueurConcret> _joueurs;
        Plateau _plateau;
        MonteurPartie _monteur;
        Combat _singletonCombat;
        private int _nbJoueurs;

        /** cf interface */
        public PartieConcret(int taillePlateau, Dictionary<String,int> players)
        {
            _joueurs = new List<JoueurConcret>();
            _monteur = new MonteurPartieConcret(taillePlateau);
            _plateau = _monteur.Plateau;
            _singletonCombat = _monteur.singletonCombat();

            int numPlayer = 0;

            foreach (KeyValuePair<String, int> pair in players)
            {
                _monteur.creerJoueur(pair.Key, pair.Value, numPlayer++);
            }
            _nbJoueurs = numPlayer;

        }

        /** cf interface */
        public List<JoueurConcret> Joueurs
        {
             get
            {
                throw new NotImplementedException();
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

    }
}
