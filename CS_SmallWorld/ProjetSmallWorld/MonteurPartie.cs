using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface MonteurPartie
     * 
     * \brief Le monteur d'une partie. Cette classe crée le plateau, les joueurs etc. pour la partie.
     */
    public interface MonteurPartie
    {
        /**
         * \fn property List<BonusCase> PositionsDepart (lecture seule)
         * 
         * \brief Contient la liste des positions de départ pour les joueurs
         */
        List<BonusCase> CasesDepart
        {
            get;
        }

        /**
         * \fn proterty Plateau Plateau
         * 
         * \brief Le plateau de la partie.
         */
        Plateau Plateau
        {
            get;
        }

        /**
         * \fn Joueur creerJoueur(string name, int peuple, int numJoueur)
         * 
         * \brief Crée un joueur avec son nom et le peuple choisi, et positionne ses unités sur
         * sa case de départ selon son numéro.
         * 
         * \return le Joueur créé
         */
        Joueur creerJoueur(string name, int peuple, int numJoueur);

        /**
         * \fn Combat singletonCombat()
         * 
         * \brief génère le singleton gérant les combats.
         * 
         * \return Combat le singleton gérant les combats
         */
        Combat singletonCombat();
    }
}
