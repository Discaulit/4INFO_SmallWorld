using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public abstract class PeupleAbstrait : Peuple
    {
        protected Unite _unite;

        protected List<Unite> _troupes;

        Unite Peuple.Unite
        {
            get { return _unite; }
        }

        Unite Peuple.getUneUnite(int numUnite)
        {
            return _troupes.ElementAt(numUnite);
        }

        protected abstract void fabriqueUnite(JoueurConcret j);

    }
}
