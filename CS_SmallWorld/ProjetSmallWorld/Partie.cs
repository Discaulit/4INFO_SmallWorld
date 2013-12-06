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
        List<JoueurConcret> Joueurs
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

    }
}
