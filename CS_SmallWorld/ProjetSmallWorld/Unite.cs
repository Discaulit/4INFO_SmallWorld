using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetSmallWorld
{
    public interface Unite
    {
        Case CaseCourante
        {
            get;
            set;
        }

        bool estAmie(Unite u);

        void deplacer(Case c);

        void detruire();
    }
}
