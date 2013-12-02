using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class FabCaseConcret : FabCase
    {
        private CaseMontagneConcret _caseMontagne;
        private CaseForetConcret _caseForet;
        private CaseDesertConcret _caseDesert;
        private CaseEauConcret _caseEau;
        private CasePlaineConcret _casePlaine;

        public FabCaseConcret()
        {
            _caseMontagne = new CaseMontagneConcret();
            _caseForet = new CaseForetConcret();
            _caseDesert = new CaseDesertConcret();
            _caseEau = new CaseEauConcret();
            _casePlaine = new CasePlaineConcret();

        }

        public CaseMontagneConcret CaseMontagne
        {
            get
            {
                return _caseMontagne;
            }
        }

        public CasePlaineConcret CasePlaine
        {
            get
            {
                return _casePlaine;
            }
        }

        public CaseEauConcret CaseEau
        {
            get
            {
                return _caseEau;
            }
        }

        public CaseDesertConcret CaseDesert
        {
            get
            {
                return _caseDesert;
            }
        }

        public CaseForetConcret CaseForet
        {
            get
            {
                return _caseForet;
            }
        }
    }
}
