using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapperLibSmallWorld;

namespace CS_SmallWorld
{
    public class StrategiePlateauConcret : StrategiePlateau
    {
        int[,] _carte;

        public StrategiePlateauConcret(int taille)
        {
            creerPlateau(taille);
        }

        public void creerPlateau(int taille)
        {
            //Tableau a deux dimensions !
            _carte = new int[taille, taille];

            List<int> matrice = new WrapperLibsSmallWorld(taille).getMap();

            for (int x = 0; x < taille; x++)
            {
                for (int y = 0; y < taille; y++)
                {
                    _carte[x, y] = matrice[(x * taille) + y];
                }
            }
        }

        public int[,] Carte
        {
            get { return _carte; }
        }
    }
}
