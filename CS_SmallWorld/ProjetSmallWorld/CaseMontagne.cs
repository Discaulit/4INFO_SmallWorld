using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface CaseMontagne : TypeCase
    {
        List<CaseMontagne> AllMontagnes
        {
            get;
        }

        void ajouterMontagne();
    }
}
