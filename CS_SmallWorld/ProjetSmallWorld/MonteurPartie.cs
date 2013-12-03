using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface MonteurPartie
    {
        Plateau construirePlateau(int taillePlateau);

        Position positionDepart(int taillePlateau);

        Joueur creerJoueur(Peuple p, Position startCase);
    }
}
