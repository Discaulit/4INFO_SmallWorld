using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class CaseAbstrait
     * 
     * \brief implémente Case. Contient tout ce qui est commun à toutes les cases
     */
    public abstract class CaseAbstrait : Case
    {
        /** Liste des unités présentes sur cette case. */
        protected List<Unite> _unitePresente;

        /** cf interface */
        public Unite getMeilleureUnite()
        {
            Unite best = null;

            if (_unitePresente.Count > 0)
            {
                best =_unitePresente.ElementAt(0);
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
    }
}
