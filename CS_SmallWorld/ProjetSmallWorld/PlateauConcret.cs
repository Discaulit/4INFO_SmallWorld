﻿using System;
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
        private int _taille;

        public PlateauConcret(int taille)
        {
            _fabCase = new FabCaseConcret();
            _strategie = new StrategiePlateauConcret(taille, _fabCase);
            _carteCase = _strategie.Carte;
            _taille = taille;
        }

        public int Taille
        {
            get { return _taille; }
        }

        public TypeCase getCaseAt(Position p)
        {
            return _carteCase[p.X, p.Y];
        }

        public Unite getUniteAt(Position p)
        {
            return _carteCase[p.X, p.Y].UnitePresente;
        }
    }
}
