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
    public class CombatConcret : Combat
    {
        WrapperLibsSmallWorld _wrapper;

        private static bool _instance;
        
        /**
         * \fn Constructeur de la classe
         */
        public CombatConcret(WrapperLibsSmallWorld wrapper)
        {
            if (!_instance)
            {
                _instance = true;
                _wrapper = wrapper;
            }
            //TODO : améliorer ce "singleton"
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
        public int lancerCombat(Unite uniteAttaque, BonusCase caseDef)
        {
            Unite uniteDef = caseDef.getMeilleureUnite();
            List<int> resCombat = _wrapper.combatResult(uniteAttaque.PV, uniteDef.PV,1,2,5);
            uniteAttaque.PV = resCombat[0];
            uniteDef.PV = resCombat[1];
            if (uniteAttaque.PV > 0)
            {
                if (uniteDef.PV > 0)
                    return 0; //Atq vivant, Def vivant = match null
                else
                    return 1; // Atq vivant, Def mort = victoire attaquant
            }
            else
                return -1; // Atq mort = victoire def
        }
    }
}
