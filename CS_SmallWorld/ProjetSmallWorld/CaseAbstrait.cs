using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public abstract class CaseAbstrait : Case
    {
        private List<Unite> _unitePresente;

        private Position _pos;

        public Position Position
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Unite UnitePresente
        {
            get { if (_unitePresente.Count > 0)
                    return _unitePresente.ElementAt(0);
                else
                    return null; }
            set { _unitePresente.Add(value); }
        }

        public Unite getMeilleureUnite()
        {
            Unite best = _unitePresente.ElementAt(0);
            foreach (Unite u in _unitePresente)
                if (u.PV > best.PV)
                    best = u;

            return best;
        }
    }
}
