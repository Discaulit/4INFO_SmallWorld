using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface BonusCase
     * 
     * \brief Décorateur de Case
     * */
    public interface BonusCase : Case
    {
        /**
         * \fn property TypeCase TCase
         * 
         * \brief  Le type de la case.
         */
        TypeCase TCase
        {
            get;
        }

        /**
         * \fn property Position Position
         * 
         * \brief La position de la case sur le plateau.
         */
        Position Position
        {
            get;
        }
    }
}
