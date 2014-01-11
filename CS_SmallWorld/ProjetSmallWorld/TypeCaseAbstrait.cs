using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;

namespace CS_SmallWorld
{
    /**
     * \class TypeCaseAbstrait
     * 
     * \brief Hérite de CaseAbstrait et est mère des cases concrètes
     */
    public abstract class TypeCaseAbstrait : CaseAbstrait, TypeCase
    {
        public String Name { get; set; }
    }
}
