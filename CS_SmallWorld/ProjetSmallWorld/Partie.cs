using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
         * \class interface Partie
         * 
         * \brief Une partie de SmallWorld. C'est la "classe principale".
         * 
         */
    public interface Partie
    {
        /**
         * \fn property Joueurs (lecture seule)
         * 
         * \brief La liste des joueurs de la partie.
         * 
         */
        List<Joueur> Joueurs
        {
            get;
        }

        /**
         * \fn property JoueurCourant (lecture-écriture)
         * 
         * \brief Le joueur à qui c'est le tour de jouer.
         * 
         */
        Joueur JoueurCourant
        {
            get;
        }

        /**
         * \fn property Plateau (lecture seule)
         * 
         * \brief Le plateau sur lequel se déroule la partie.
         * 
         */
        Plateau Plateau
        {
            get;
        }

        /**
         * \fn property NbTourMax (lecture seule)
         * 
         * \brief Le nombre de tour de la partie.
         * 
         */
        int NbTourMax
        {
            get;
        }

        /**
         * \fn property NumTour (lecture-ecriture)
         * 
         * \brief Le nombre de tour de la partie.
         * 
         */
        int NumTour
        {
            set;
            get;
        }

        /**
         * \fn void finirTour()
         * 
         * \brief Finit le tour du joueur courant en comptant ses points
         * et passe au joueur suivant.
         */
        bool finirTour();
    }
}
