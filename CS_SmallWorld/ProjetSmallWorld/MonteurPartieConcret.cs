using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapperLibSmallWorld;

namespace CS_SmallWorld
{
    /**
     * \class MonteurPartieConcret
     * 
     * \brief implémentation de MonteurPartie
     */
    public class MonteurPartieConcret : MonteurPartie
    {
        WrapperLibsSmallWorld _wrapper;
        int _taillePlateau;
        List<BonusCase> _casesDepart;
        Plateau _plateau;
        int _nbTourMax;
        int _nbUnite;

        /**
         * \fn Constructeur de la casse
         */
        public MonteurPartieConcret(int taillePlateau)
        {
            _taillePlateau = taillePlateau;
            _wrapper = new WrapperLibsSmallWorld(taillePlateau);
            _plateau = new PlateauConcret(_taillePlateau, _wrapper);
            _casesDepart = positionsDepart();

            switch (taillePlateau)
            {
                case 5:
                    _nbUnite = 4;
                    _nbTourMax = 5;
                    break;
                case 10:
                    _nbUnite = 6;
                    _nbTourMax = 20;
                    break;
                case 15:
                    _nbUnite = 8;
                    _nbTourMax = 30;
                    break;
                default:
                    _nbUnite = 4;
                    _nbTourMax = 5;
                    break;
            }
        }

        /** cf interface */
        public Plateau Plateau
        {
            get { return _plateau; }
        }

        /** cf interface */
        public List<BonusCase> CasesDepart
        {
            get { return _casesDepart; }
        }

        public int NbTourMax
        {
            get { return _nbTourMax; }
        }

        /**
         * \fn private List<TypeCase> positionsDepart()
         * 
         * \brief Crée la liste des cases de départ des joueurs.
         * 
         * \return La liste des cases de départ des joueurs
         */
        private List<BonusCase> positionsDepart()
        {
            List<BonusCase> pos = new List<BonusCase>();
            List<int> coordStart = _wrapper.getStartCases(_taillePlateau);

            Position p1 = new Position(coordStart[0], coordStart[1]);
            Position p2 = new Position(coordStart[2], coordStart[3]);

            pos.Add(_plateau.getCaseAt(p1));
            pos.Add(_plateau.getCaseAt(p2));
            return pos;

        }

        /** cf interface */
        public Joueur creerJoueur(string name, int peuple, int numJ)
        {
            return new JoueurConcret(name, peuple, _casesDepart[numJ], _nbUnite);
        }

        /** cf interface */
        public CombatConcret singletonCombat()
        {
            CombatConcret cc = CombatConcret.Instance;
            cc.mettreWrapper(_wrapper);
            return cc;
        }
    }
}
