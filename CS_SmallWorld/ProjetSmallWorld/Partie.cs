using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Partie
    {
        List<JoueurConcret> Joueurs
        {
            get;
            set;
        }

        Plateau Plateau
        {
            get;
            set;
        }
        MonteurPartie Monteur
        {
            get;
            set;
        }

    }
}
