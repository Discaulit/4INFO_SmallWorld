﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SmallWorld
{
    public class Position
    {
        private int _x;
        private int _y;
        public Position(int x, int y)
        {
            X = _x;
            Y = _y;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
