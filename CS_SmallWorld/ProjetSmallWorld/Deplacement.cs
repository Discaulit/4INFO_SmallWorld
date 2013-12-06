using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface Deplacement
     * 
     * \brief Gere les déplacement
     */
    public interface Deplacement
    {
        /**
         * L'unite en cours de déplacement
         */

        Unite uniteCourante
        {
            get;
            set;
        }

        /**
         * \fn bool estAPorte(Case caseVisee)
         * 
         * \brief verifie si la caseVisee est a porté de deplacement de l'uniteCourante,
         * en tenant compte des différents bonus.
         * 
         * \return true si la case est a portée pour cette unite, false sinon.
         */
        bool estAPorte(Case caseVisee);
    }
}
