using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Joueur
    {
        Peuple peuple
        {
            get;
            set;
        }

        int points
        {
            get;
            set;
        }
    }
}
