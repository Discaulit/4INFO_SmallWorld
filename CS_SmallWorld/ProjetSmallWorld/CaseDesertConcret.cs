using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{

    /**
     * \class CasDesertConcret
     * 
     * \brief implémente CaseDesert
     */
    public class CaseDesertConcret : TypeCaseAbstrait, CaseDesert
    {
        public CaseDesertConcret()
        {
            Name = "Désert";
        }
    }
}
