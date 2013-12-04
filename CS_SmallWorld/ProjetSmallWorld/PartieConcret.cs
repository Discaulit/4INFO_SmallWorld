using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class PartieConcret : Partie
    {
        List<JoueurConcret> _joueurs;
        Plateau _plateau;
        MonteurPartie _monteur;
        private int _nbJoueurs;

        public PartieConcret(int taillePlateau, Dictionary<String,Peuple> players)
        {
            _joueurs = new List<JoueurConcret>();
            _monteur = new MonteurPartieConcret();
            _plateau = _monteur.construirePlateau(taillePlateau);

            int numPlayer = 0;

            foreach (KeyValuePair<String, Peuple> pair in players)
            {
                _monteur.creerJoueur(_plateau, pair.Key, pair.Value, numPlayer++);
            }
            _nbJoueurs = numPlayer;

        }

        public List<JoueurConcret> Joueurs
        {
             get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Plateau Plateau
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public MonteurPartie Monteur
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
