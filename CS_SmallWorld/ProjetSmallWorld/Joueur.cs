using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Joueur
    {
        string Name
        {
            get;
        }
        Peuple Peuple
        {
            get;
        }

        int Points
        {
            get;
            set;
        }

        //TODO: ajouter couleur
    }
}
