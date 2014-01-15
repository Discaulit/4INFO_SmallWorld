using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    [Serializable()]
    public class CaseMontagneConcret : TypeCaseAbstrait, CaseMontagne
    {
        public CaseMontagneConcret()
        {
            Name = "Montagne";
        }
    }
}
