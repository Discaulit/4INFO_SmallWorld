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

        public PartieConcret()
        {
            _joueurs = new List<JoueurConcret>();
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
