using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class PlateauConcret : Plateau
    {
        private StrategiePlateau _strategie;
        private FabCase _fabCase;
        private TypeCase[,] _carteCase;
        private List<Unite>[,] _carteTroupes;

        public PlateauConcret(int taille)
        {
            _fabCase = new FabCaseConcret();
            _strategie = new StrategiePlateauConcret(taille);
            _carteCase = new TypeCase[taille, taille];
            _carteTroupes = new List<Unite>[taille, taille];
        }

        public TypeCase getCaseAt(Position p)
        {
            return _carteCase[p.X, p.Y];
        }

        public List<Unite>getTroupesAt(Position p)
        {
            if (_carteTroupes[p.X, p.Y].Count > 0)
                return _carteTroupes[p.X, p.Y];
            else
                return null;
        }
    }
}
