using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class FabCaseConcret
     * 
     * \brief implémente FabCase
     */
    public class FabCaseConcret : FabCase
    {
        private CaseMontagneConcret _caseMontagne;
        private CaseForetConcret _caseForet;
        private CaseDesertConcret _caseDesert;
        private CaseEauConcret _caseEau;
        private CasePlaineConcret _casePlaine;

        /**
         * \fn Constructeur de la classe
         */
        public FabCaseConcret()
        {
            _caseMontagne = new CaseMontagneConcret();
            _caseForet = new CaseForetConcret();
            _caseDesert = new CaseDesertConcret();
            _caseEau = new CaseEauConcret();
            _casePlaine = new CasePlaineConcret();

        }

        /** cf interface */
        public CaseMontagneConcret CaseMontagne
        {
            get
            {
                return _caseMontagne;
            }
        }

        /** cf interface */
        public CasePlaineConcret CasePlaine
        {
            get
            {
                return _casePlaine;
            }
        }

        /** cf interface */
        public CaseEauConcret CaseEau
        {
            get
            {
                return _caseEau;
            }
        }

        /** cf interface */
        public CaseDesertConcret CaseDesert
        {
            get
            {
                return _caseDesert;
            }
        }

        /** cf interface */
        public CaseForetConcret CaseForet
        {
            get
            {
                return _caseForet;
            }
        }
    }
}
