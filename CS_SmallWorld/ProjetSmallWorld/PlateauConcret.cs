using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class PlateauConcret
     * 
     * \brief implémente Plateau
     */
    public class PlateauConcret : Plateau
    {
        private StrategiePlateau _strategie;
        private FabCase _fabCase;
        private BonusCase[,] _carteCase;
        private int _taille;
        /**
         * \fn Constructeur de la classe
         */
        public PlateauConcret(int taille, wrapperLibSmallWorld.WrapperLibsSmallWorld wrapper)
        {
            _fabCase = new FabCaseConcret();
            _strategie = new StrategiePlateauConcret(taille, _fabCase, wrapper);
            _carteCase = _strategie.Plateau;
            _taille = taille;
        }

        /** cf interface */
        public int Taille
        {
            get { return _taille; }
        }

        /** cf interface */
        public BonusCase getCaseAt(Position p)
        {
            return _carteCase[p.X, p.Y];
        }

        /** cf interface */
        public Unite getUniteAt(Position p)
        {
            //le calcul ne sera pas trop long ici car il y aura rarement plus de 5 unités sur une case
            return _carteCase[p.X, p.Y].getMeilleureUnite();
        }
    }
}
