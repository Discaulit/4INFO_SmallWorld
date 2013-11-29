using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Case
    {
        /*Position Pos
        {
            get;
            set;
        }*/

        // Le setter mettra la 1ere Unite a aller dans la case ; le getter la retournera,
        //ou null si Case vide
        Unite Unite
        {
            get;
            set;
        }
    }

    class Position
    {
        Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        int X
        {
            get { return X; }
            set { X = value; }
        }

        int Y
        {
            get { return Y; }
            set { Y = value; }
        }
    }
}
