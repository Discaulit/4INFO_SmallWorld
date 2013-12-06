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

        public MonteurPartieConcret(int taillePlateau)
        {
            _taillePlateau = taillePlateau;
            _wrapper = new WrapperLibsSmallWorld(taillePlateau);
            _plateau = new PlateauConcret(_taillePlateau, _wrapper);
            _casesDepart = positionsDepart();
        }
        
        public Plateau Plateau
        {
            get { return _plateau; }
        }

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
            pos.Add(_plateau.getCaseAt(new Position(0,0)));
            pos.Add(_plateau.getCaseAt(new Position(_taillePlateau - 1, _taillePlateau - 1)));
            return pos;

        }

        public Joueur creerJoueur(string name, int peuple, int numJ)
        {
            return new JoueurConcret(name, peuple, _casesDepart[numJ], _taillePlateau);
        }

        public Combat singletonCombat()
        {
            return new CombatConcret(_wrapper);
        }
    }
}
