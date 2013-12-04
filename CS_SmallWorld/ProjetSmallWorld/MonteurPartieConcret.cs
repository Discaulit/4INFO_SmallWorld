using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class MonteurPartieConcret : MonteurPartie
    {

        public MonteurPartieConcret() { }

        public Plateau construirePlateau(int taillePlateau)
        {
           return new PlateauConcret(taillePlateau);
        }

        private Position positionDepart(Plateau p ,int numJ)
        {
            switch (numJ)
            {
                case 0:
                    return new Position(0, 0);
                case 1:
                    return new Position(p.Taille - 1, p.Taille - 1);
                default:
                    return null;
            }
        }

        public Joueur creerJoueur(Plateau plateau, String name, Peuple peuple, int numJ)
        {
            TypeCase startCase = plateau.getCaseAt(positionDepart(plateau, numJ));
            return new JoueurConcret(name, peuple, startCase);
        }
    }
}
