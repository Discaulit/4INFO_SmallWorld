using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class PeupleVikingConcret : PeupleAbstrait, PeupleViking
    {
        PeupleVikingConcret(JoueurConcret j, int nbUnite)
        {
            
        }

        protected override void fabriqueUnite(JoueurConcret j)
        {
            _troupes.Add(new UniteVikingConcret());
        }
    }
}
