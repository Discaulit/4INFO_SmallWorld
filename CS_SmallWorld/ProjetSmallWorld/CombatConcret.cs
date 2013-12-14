using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapperLibSmallWorld;

namespace CS_SmallWorld
{
    /**
     * \class CombatConcret
     * 
     * \brief implémente Combat
     */
    public sealed class CombatConcret : Combat
    {
        WrapperLibsSmallWorld _wrapper;

        private static readonly CombatConcret _instance = new CombatConcret();

        /**
         * \fn Constructeur de la classe
         */
        private CombatConcret() { _wrapper = null; /* initialisé via la fonction mettreWrapper(w)*/ }

        /**
         * \fn property le singleton Combat
         */
        public static CombatConcret Instance
        {
            get
            {
                return _instance;
            }
        }

        /**
         * \fn mettreWrapper(WrapperLibsSmallWorld w)
         * 
         * \brief Permet de donner le wrapper au singleton
         * 
         * \param[in] WrapperLibsSmallWorld w le wrapper à indiquer
         */
        public void mettreWrapper(WrapperLibsSmallWorld w)
        {
            _wrapper = w;
        }

        /**
         * \fn int lancerCombat(Unite uniteAttaque, Case caseDef)
         * 
         * \brief lance un combat entre l'uniteAttaque et un défenseur de la caseDef.
         * 
         * \param[in] Unite uniteAttaque l'unite attaquante
         * 
         * \param[out] Case caseDef la case qui doit se défendre
         * 
         * \return 1 si l'attaquant gagne, 0 si match nul, -1 si l'attaquant meurt
         */
        public void lancerCombat(Unite uniteAttaque, BonusCase caseDef)
        {
            Unite uniteDef = caseDef.getMeilleureUnite();
            List<int> resCombat = _wrapper.combatResult(uniteAttaque.PV, uniteDef.PV, 3, 2, 5);
            uniteAttaque.PV = resCombat[0];
            uniteDef.PV = resCombat[1];
        }
    }
}
