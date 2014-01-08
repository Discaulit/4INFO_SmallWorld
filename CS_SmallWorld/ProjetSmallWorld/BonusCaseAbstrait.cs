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
        protected List<Unite> _unitesPresentes;

        protected List<BonusCase> _voisines;

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

        public List<BonusCase> Voisines
        {
            get
            {
                return _voisines;
            }
        }

        /** cf interface */
        public Unite getMeilleureUnite()
        {
            Unite best = null;

            if (_unitesPresentes.Count > 0)
            {
                best = _unitesPresentes.ElementAt(0);
                foreach (Unite u in _unitesPresentes)
                    if (u.PV > best.PV)
                        best = u;
            }

            return best;
        }

        /** cf interface */
        public void positionnerUnite(Unite u)
        {
            _unitesPresentes.Add(u);
        }

        /** cf interface */
        public void enleverUneUnite(Unite u)
        {
            if (_unitesPresentes.Contains(u))
                _unitesPresentes.Remove(u);
            else
                throw new InvalidOperationException("L'unite passée en paramètre ne peut pas être retirée car "
                    + "elle ne fait pas partie des unités présentent sur cette case.");
        }

        public int distance(BonusCase c)
        {
            return (Math.Abs(this.Position.X - c.Position.X) + Math.Abs(this.Position.Y - c.Position.Y));
        }

        public int NombreUniteSurCase
        {
            get
            {
                return _unitesPresentes.Count;
            }
        }
    }
}
