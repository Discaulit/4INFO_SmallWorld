using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
   /**
    * \class interface Combat
    * 
    * \brief La classe gérant les combats
    */
    public interface Combat
    {        
         /**
          * \fn bool lancerCombat(Unite uniteAttaque, Case caseDef)
          * 
          * \brief commence le combat de l'uniteAttaque sur la caseDef
          * 
          * \return true si l'attaquant a gagner ce combat
          */
        int lancerCombat(Unite uniteAttaque, Case caseDef);
    }

}
