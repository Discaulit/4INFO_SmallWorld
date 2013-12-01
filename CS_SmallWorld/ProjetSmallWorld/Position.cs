using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SmallWorld
{
    public class Position
    {
        Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get { return X; }
            set { X = value; }
        }

        public int Y
        {
            get { return Y; }
            set { Y = value; }
        }
    }
}
