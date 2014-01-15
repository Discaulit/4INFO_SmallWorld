using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class UniteGauloisConcret
     * 
     * \brief Une Unite Gauloise.
     */
    [Serializable()]
    public class UniteGauloisConcret : UniteAbstrait, UniteGaulois
    {
        /**
         * \fn Constructeur de la classe
         */
        public UniteGauloisConcret(JoueurConcret j, BonusCase startCase)
        {
            _joueur = j;
            _ptVie = 5;
            _ptsDeplacement = 2;
            _caseCourante = startCase;
            _caseCourante.positionnerUnite(this);
        }

        /** cf interface */
        protected override int avantageTerrain()
        {
            if (_caseCourante.TCase is CasePlaineConcret)
                return 1;
            else if (_caseCourante.TCase is CaseMontagneConcret)
                return -1;
            else
                return 0;
        }

        protected override bool deplacementPeuple(BonusCase caseCible)
        {
            // Un Gaulois peut se déplacer deux cases plus loin s'il est sur une case Plaine et que c'est
            // son premier déplacement, 1 case sinon.
            Boolean cheminsanseau = false;
            if ((_caseCourante.TCase is CasePlaine) && (_caseCourante.distance(caseCible) < 3) && (_ptsDeplacement > 1))
            {
                foreach (BonusCase c in _caseCourante.Voisines)
                {
                    if (_caseCourante.distance(c) == 1 && caseCible.distance(c) == 1 && !(c.TCase is CaseEau))
                    {
                        cheminsanseau = true;
                    }
                }
            }

            return (cheminsanseau || _caseCourante.distance(caseCible) < 2);
        }
    }
}
