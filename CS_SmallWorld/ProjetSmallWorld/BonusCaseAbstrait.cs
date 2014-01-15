using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CS_SmallWorld
{
    /**/
    [Serializable()]
    public class BonusCaseAbstrait : CaseAbstrait, BonusCase
    {
        /** TypeCase _tcase le type de la case */
        protected TypeCase _tcase;

        /** Liste des unités présentes sur cette case. */
        protected List<Unite> _unitesPresentes;

        protected List<BonusCase> _voisines;

        protected Position _position;

        protected int _nbrUnitesCase;

        protected bool _pointsGeneres;

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

        public List<Unite> UnitesPresentes
        {
            set 
            {
                _unitesPresentes = value;
            }
            get 
            {
                return _unitesPresentes;
            }
        }

        public int NbrUnitesCase
        {
            get
            {
                return UnitesPresentes.Count;
            }
            set
            {
                _nbrUnitesCase = value;
            }
        }

        public bool PointsGeneres
        {
            get
            {
                return _pointsGeneres;
            }
            set
            {
                _pointsGeneres = value;
            }
        }

        /** cf interface */
        public Unite getMeilleureUnite()
        {
            Unite best = null;

            if (UnitesPresentes.Count > 0)
            {
                best = UnitesPresentes.ElementAt(0);
                foreach (Unite u in UnitesPresentes)
                    if (u.PV > best.PV)
                        best = u;
            }

            return best;
        }

        /** cf interface */
        public void positionnerUnite(Unite u)
        {
            UnitesPresentes.Add(u);
        }

        /** cf interface */
        public void enleverUneUnite(Unite u)
        {
            if (UnitesPresentes.Contains(u))
                UnitesPresentes.Remove(u);
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
