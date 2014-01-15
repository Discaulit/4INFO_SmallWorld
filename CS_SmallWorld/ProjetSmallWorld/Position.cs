using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SmallWorld
{
    /**
     * \class Position
     * 
     * \brief représente une position(x,y) sur le plateau
     */
    [Serializable()]
    public class Position
    {
        private int _x;
        private int _y;

        /**
         * \fn Constructeur de la classe
         */
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /**
         * \fn property int X
         * 
         * \brief la coordonnée en X
         */
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /**
         * \fn property int  Y
         * 
         * \brief la coordonnée en Y
         */
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
