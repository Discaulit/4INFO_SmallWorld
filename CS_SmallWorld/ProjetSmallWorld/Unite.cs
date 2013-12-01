using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface Unite
    {
        JoueurConcret Joueur
        {
            get;
            set;
        }

        TypeCase CaseCourante
        {
            get;
            set;
        }

        int PV
        {
            get;
            set;
        }
        
        int PtsGenerer
        {
            get;
        }

        bool estAmie(Unite u);

        void deplacer(Case c);

        void detruire();
    }
}
