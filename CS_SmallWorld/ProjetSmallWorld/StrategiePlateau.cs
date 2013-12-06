using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface StrategiePlateau
     * 
     * \brief Cree le Plateau selon la Strategie choisie.
     * Ici il n'y a qu'un seul algo donc ne sert pas à grand chose...
     */
    public interface StrategiePlateau
    {
        /**
         * \fn property TypeCase[,] Plateau
         * 
         * \brief le Plateau créé par la Strategie
         */
        TypeCase[,] Plateau
        {
            get;
        }
    }

}
