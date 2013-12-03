using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Plateau
    {
        TypeCase getCaseAt(Position p);
        Unite getUniteAt(Position p);
    }
}
