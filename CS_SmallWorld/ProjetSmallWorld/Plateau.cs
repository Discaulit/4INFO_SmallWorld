using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface Plateau
     * 
     * \brief Modélise le Plateau sur lequel se déroule la partie.
     */
    public interface Plateau
    {
        /**
         * \fn property int Taille
         * 
         * \brief la longueur d'un coté du plateau.
         */
        int Taille
        {
            get;
        }
        /**
         * \fn TypeCase getCaseAt(Position p)
         * 
         * \brief Retourne la case à la position donnée en paramètre.
         * 
         * \param[in] Position p la position dont on veut récupérer la case
         * 
         * \return TypeCase la case dont la position est celle donnée en paramètre
         */
        TypeCase getCaseAt(Position p);

        /**
         * \fn TypeCase getUniteAt(Position p)
         * 
         * \brief Retourne une unité présente à la position donnée en paramètre, s'il y en a.
         * 
         * \param[in] Position p la position dont on veut récupérer l'unité
         * 
         * \return Unite une unité dont la position est celle donnée en paramètre
         */
        Unite getUniteAt(Position p);
    }
}
