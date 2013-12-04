using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapperLibSmallWorld;

namespace CS_SmallWorld
{
    public class StrategiePlateauConcret : StrategiePlateau
    {
        private TypeCase[,] _carte;
        private FabCase _fabriqueCase;

        public StrategiePlateauConcret(int taille, FabCase fab)
        {
            _fabriqueCase = fab;
            creerPlateau(taille);       
        }

        public void creerPlateau(int taille)
        {
            //Tableau a deux dimensions !
            _carte = new TypeCase[taille, taille];

            List<int> matrice = new WrapperLibsSmallWorld(taille).getMap();

            for (int x = 0; x < taille; x++)
            {
                for (int y = 0; y < taille; y++)
                {
                    // t_montagne = 0, t_plaine, t_desert, t_eau, t_foret
                    switch(matrice[(x * taille) + y])
                    {
                        case 0:
                        _carte[x, y] = _fabriqueCase.CaseMontagne;
                        break;
                        case 1:
                        _carte[x, y] = _fabriqueCase.CasePlaine;
                        break;
                        case 2:
                        _carte[x, y] = _fabriqueCase.CaseDesert;
                        break;
                        case 3:
                        _carte[x, y] = _fabriqueCase.CaseEau;
                        break;
                        case 4:
                        _carte[x, y] = _fabriqueCase.CaseForet;
                        break;
                    }
                }
            }
        }

        public TypeCase[,] Carte
        {
            get { return _carte; }
        }
    }
}
