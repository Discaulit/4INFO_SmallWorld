using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class PeupleAbstrait
     * 
     * \brief "implémente" Peuple.
     */
    public abstract class PeupleAbstrait : Peuple
    {
        /**
         * \fn void fabriqueUnite(JoueurConcret j, TypeCase startCase)
         * 
         * \brief La fabrique d'Unite du Peuple. Crée une Unite et
         * lui associe le joueur possédant ce peuple ainsi que sa position de départ
         */
        protected abstract void fabriqueUnite(JoueurConcret j, BonusCase startCase);
    }
}
