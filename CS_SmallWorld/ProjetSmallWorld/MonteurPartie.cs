using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface MonteurPartie
    {
        Plateau construirePlateau(int taillePlateau);

        Joueur creerJoueur(Plateau plateau, String name, Peuple peuple, int numJ);
    }
}
