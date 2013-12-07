using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**/
    public class BonusCaseAbstrait : CaseAbstrait, BonusCase
    {
        /** Position _position la position de la case sur le plateau */
        protected Position _position;
        /** TypeCase _tcase le type de la case */
        protected TypeCase _tcase;

        public Position Position
        {
            get { return _position; }
        }

        public TypeCase TCase
        {
            get { return _tcase; } 
        }
    }
}
