using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
   
    public interface Combat
    {
        private Unite uniteAtq{
            get;
            set;
        }

        private Unite uniteDef{
            get;
            set;
        }

        /**
         * \fn bool lancerCombat(Unite uniteAttaque, Case caseDef)
         * 
         * \brief commence le combat de l'uniteAttaque sur la caseDef
         * 
         * \return true si l'attaquant a gagner ce combat
         */
        bool lancerCombat(Unite uniteAttaque, Case caseDef);

        /**
         * \fn void calculerProbas()
         * 
         * \brief calcule les probabilites de victoire des unites qui combattent actuellement.
         */
        void calculerProbas();
    }

}
