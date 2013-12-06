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
    public class StrategiePlateauConcret : StrategiePlateau
    {
        private TypeCase[,] _plateau;
        private FabCase _fabriqueCase;
        WrapperLibsSmallWorld _wrapper;

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
            _plateau = new TypeCase[taille, taille];

            List<int> matrice = _wrapper.getMap();

            for (int x = 0; x < taille; x++)
            {
                for (int y = 0; y < taille; y++)
                {
                    // t_montagne = 0, t_plaine, t_desert, t_eau, t_foret
                    switch (matrice[(x * taille) + y])
                    {
                        case 0:
                            _plateau[x, y] = _fabriqueCase.CaseMontagne;
                            _plateau[x, y].Position.X = x;
                            _plateau[x, y].Position.Y = y;
                            break;
                        case 1:
                            _plateau[x, y] = _fabriqueCase.CasePlaine;
                            _plateau[x, y].Position.X = x;
                            _plateau[x, y].Position.Y = y;
                            break;
                        case 2:
                            _plateau[x, y] = _fabriqueCase.CaseDesert;
                            _plateau[x, y].Position.X = x;
                            _plateau[x, y].Position.Y = y;
                            break;
                        case 3:
                            _plateau[x, y] = _fabriqueCase.CaseEau;
                            _plateau[x, y].Position.X = x;
                            _plateau[x, y].Position.Y = y;
                            break;
                        case 4:
                            _plateau[x, y] = _fabriqueCase.CaseForet;
                            _plateau[x, y].Position.X = x;
                            _plateau[x, y].Position.Y = y;
                            break;
                    }
                }
            }
        }

        public TypeCase[,] Plateau
        {
            get { return _plateau; }
        }
    }
}
