using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Case
    {
        int posX
        {
            get;
            set;
        }

        int posY
        {
            get;
            set;
        }
        /**
         * \fn Unite contient()
         * 
         * \brief indique quelle unite est presente sur la case.
         * 
         * \return une des unites présentes sur la case, null si la case est vide. 
         */
        Unite contient();
    }
}
