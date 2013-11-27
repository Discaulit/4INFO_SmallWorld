using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Unite
    {
        Joueur Joueur
        {
            get;
            set;
        }

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
