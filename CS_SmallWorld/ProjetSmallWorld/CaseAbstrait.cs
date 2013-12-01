using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public abstract class CaseAbstrait : Case
    {
        private List<Unite> _unitePresentes;

        private Position _pos;

        public Position Position
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Unite UnitePresentes
        {
            get { if (_unitePresentes.Count > 0)
                    return _unitePresentes.ElementAt(0);
                else
                    return null; }
            set { _unitePresentes.Add(value); }
        }

        public Unite getMeilleureUnite()
        {
            Unite best = _unitePresentes.ElementAt(0);
            foreach (Unite u in _unitePresentes)
                if (u.PV > best.PV)
                    best = u;

            return best;
        }
    }
}
