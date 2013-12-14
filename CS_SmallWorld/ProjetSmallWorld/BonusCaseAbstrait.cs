using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**/
    public class BonusCaseAbstrait : CaseAbstrait, BonusCase
    {
        /** TypeCase _tcase le type de la case */
        protected TypeCase _tcase;

        /** Liste des unités présentes sur cette case. */
        protected List<Unite> _unitePresente;

        protected Position _position;

        public TypeCase TCase
        {
            get { return _tcase; }
        }

        public Position Position
        {
            set { _position = value; }
            get { return _position; }
        }

        /** cf interface */
        public Unite getMeilleureUnite()
        {
            Unite best = null;

            if (_unitePresente.Count > 0)
            {
                best = _unitePresente.ElementAt(0);
                foreach (Unite u in _unitePresente)
                    if (u.PV > best.PV)
                        best = u;
            }

            return best;
        }

        /** cf interface */
        public void positionnerUnite(Unite u)
        {
            _unitePresente.Add(u);
        }

        /** cf interface */
        public void enleverUneUnite(Unite u)
        {
            if (_unitePresente.Contains(u))
                _unitePresente.Remove(u);
            else
                throw new InvalidOperationException("L'unite passée en paramètre ne peut pas être retirée car "
                    + "elle ne fait pas partie des unités présentent sur cette case.");
        }

        public int distance(BonusCase c)
        {
            return (Math.Abs(this.Position.X - c.Position.X) + Math.Abs(this.Position.Y - c.Position.Y));
        }
    }
}
