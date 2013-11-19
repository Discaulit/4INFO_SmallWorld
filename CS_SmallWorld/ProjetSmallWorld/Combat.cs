using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetSmallWorld
{
    public interface Combat
    {
        bool lancerCombat(Unite uniteCourante, Case caseAttaquee);
    }
}
