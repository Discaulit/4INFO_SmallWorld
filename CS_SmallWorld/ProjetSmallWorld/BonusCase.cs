﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface BonusCase
     * 
     * \brief Décorateur de Case
     * */
    public interface BonusCase : Case
    {
        /**
         * \fn property TypeCase TCase
         * 
         * \brief  Le type de la case.
         */
        TypeCase TCase
        {
            get;
        }

        /**
         * \fn property Position Position
         * 
         * \brief  La position de la case sur le plateau.
         */
        Position Position
        {
            set;
            get;
        }

        List<BonusCase> Voisines
        {
            get;
        }

        //Cette fonction ne sera pas trop longue car il y aura rarement plus de 5 unités sur une même case.
        //Dans le cas où le nombre d'unité grimperait, il serait judicieux de créer un getter d'UnitePresente
        //plus rapide juste pour vérifier si la case est amie ou non.
        /**
         * \fn Unite getMeilleureUnite()
         * 
         * \brief Cherche et renvoie l'Unite ayant le plus de PV dans cette case, s'il y en a.
         * 
         * \return l'Unite ayant le plus de PV, null s'il n'y a aucune Unite
         */
        Unite getMeilleureUnite();

        /**
         * \fn void positionnerUnite(Unite u)
         * 
         * \brief place l'Unite passée en paramètre sur la Case.
         * 
         * \param[in] Unite u l'Unite à positionner sur la Case
         */
        void positionnerUnite(Unite u);

        /**
         * \fn void enleverUneUnite(Unite u)
         * 
         * \brief Retire une Unite aux troupes du joueur.
         * 
         * \param[in] Unite u l'Unite à retirer
         */
        void enleverUneUnite(Unite u);

        int distance(BonusCase c);
        
        List<Unite> UnitesPresentes
        {
            get;
            set;
        }

        int NbrUnitesCase
        {
            get;
            set;
        }

        bool PointsGeneres
        {
            get;
            set;
        }
    }
}
