using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public abstract class PeupleAbstrait : Peuple
    {
        protected Unite _unite;

        public Unite Unite
        {
            get { return _unite; }
        }

        protected abstract void fabriqueUnite(JoueurConcret j);

    }
}
