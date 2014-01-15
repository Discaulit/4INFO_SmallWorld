using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapperLibSmallWorld;

namespace CS_SmallWorld
{
    /**
     * \class StrategiePlateauConcret
     * 
     * \brief implémente StrategiePlateau.
     */
    [Serializable()]
    public class StrategiePlateauConcret : StrategiePlateau
    {
        private BonusCase[,] _plateau;
        private FabCase _fabriqueCase;
        WrapperLibsSmallWorld _wrapper;

        /**
         * \fn Constructeur de la classe
         */
        public StrategiePlateauConcret(int taille, FabCase fab, WrapperLibsSmallWorld wrapper)
        {
            _wrapper = wrapper;
            _fabriqueCase = fab;
            creerPlateau(taille);
        }

        /**
         * \fn void creerPlateau(int taille)
         * 
         * \brief Cree le Plateau de la taille désiré en traduisant la matrice d'int du wrapper en
         * un tableau de TypeCase à deux dimensions pour simplifier l'utilisation.
         * 
         * \param[in] int taille la longueur d'un coté du plateau
         */
        private void creerPlateau(int taille)
        {
            //Tableau a deux dimensions !
            _plateau = new BonusCase[taille, taille];

            List<int> matrice = _wrapper.getMap();
            TypeCase tmp = null;

            for (int x = 0; x < taille; x++)
            {
                for (int y = 0; y < taille; y++)
                {
                    // t_montagne = 0, t_plaine, t_desert, t_eau, t_foret
                    switch (matrice[(x * taille) + y])
                    {
                        case 0:
                            tmp = _fabriqueCase.CaseMontagne;
                            break;
                        case 1:
                            tmp = _fabriqueCase.CasePlaine;
                            break;
                        case 2:
                            tmp = _fabriqueCase.CaseDesert;
                            break;
                        case 3:
                            tmp = _fabriqueCase.CaseEau;
                            break;
                        case 4:
                            tmp = _fabriqueCase.CaseForet;
                            break;
                    }
                    _plateau[x, y] = new CaseStandardConcret( tmp, new Position(x,y));
                    if (x > 0)
                    {
                        _plateau[x, y].Voisines.Add(_plateau[x - 1, y]);
                        _plateau[x - 1, y].Voisines.Add(_plateau[x, y]);
                    }
                    if (y > 0)
                    {
                        _plateau[x, y].Voisines.Add(_plateau[x, y - 1]);
                        _plateau[x, y - 1].Voisines.Add(_plateau[x, y]);
                    }
                }
            }
        }

        /** cf interface */
        public BonusCase[,] Plateau
        {
            get { return _plateau; }
        }
    }
}
