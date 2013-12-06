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
        List<TypeCase> _casesDepart;
        Plateau _plateau;

        /**
         * \fn Constructeur de la casse
         */
        public MonteurPartieConcret(int taillePlateau)
        {
            _taillePlateau = taillePlateau;
            _wrapper = new WrapperLibsSmallWorld(taillePlateau);
            _plateau = new PlateauConcret(_taillePlateau, _wrapper);
            _casesDepart = positionsDepart();
        }

        /** cf interface */
        public Plateau Plateau
        {
            get { return _plateau; }
        }

        /** cf interface */
        public List<TypeCase> CasesDepart
        {
            get { return _casesDepart; }
        }

        /**
         * \fn private List<TypeCase> positionsDepart()
         * 
         * \brief Crée la liste des cases de départ des joueurs.
         * 
         * \return La liste des cases de départ des joueurs
         */
        private List<TypeCase> positionsDepart()
        {
            List<TypeCase> pos = new List<TypeCase>();
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
            return new JoueurConcret(name, peuple, _casesDepart[numJ], _taillePlateau);
        }

        /** cf interface */
        public Combat singletonCombat()
        {
            return new CombatConcret(_wrapper);
        }
    }
}
