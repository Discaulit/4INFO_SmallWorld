using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class UniteVikingConcret : UniteAbstrait, UniteViking
    {
        /**
     * \class UniteVikingConcret
     * 
     * \brief Une Unite Viking.
     */
        public UniteVikingConcret(JoueurConcret j, BonusCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;
            _caseCourante.positionnerUnite(this);
        }

        protected override int avantageTerrain()
        {
            //Position pc = _caseCourante.Position;
            bool avantage = false;

            foreach (BonusCase c in _caseCourante.Voisines)
                avantage |= (c.TCase is CaseEau);

            if (avantage)
                return 1;
            else if (_caseCourante.TCase is CaseDesertConcret)
                return -1;
            else
                return 0;
        }

        protected override bool deplacementPeuple(BonusCase caseCible)
        {
            //la partie propre aux Viking est déjà traitée dans UniteAbstraite (cf CaseEau).
            return _caseCourante.Voisines.Contains(caseCible);
                //(_caseCourante.distance(caseCible) <2);
        }
    }
}
