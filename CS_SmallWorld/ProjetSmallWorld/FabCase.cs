using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface FabCase
    {
        CaseMontagneConcret CaseMontagne
        {
            get;
        }

        CaseForetConcret CaseForet
        {
            get;
        }

        CasePlaineConcret CasePlaine
        {
            get;
        }

        CaseEauConcret CaseEau
        {
            get;
        }

        CaseDesertConcret CaseDesert
        {
            get;
        }
    }
}
