using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Case
    {
        
        Position Position
        {
            get;
            set;
        }

        /** Le setter mettra la 1ere Unite a aller dans la case ; le getter la retournera,
         * ou null si Case vide
         */
        Unite UnitePresente
        {
            get;
            set;
        }

        Unite getMeilleureUnite();

    }

}
