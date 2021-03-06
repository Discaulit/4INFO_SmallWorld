﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface Unite
     * 
     * \brief Modélise une Unite d'un Peuple
     */
    public interface Unite
    {
        /**
         * \fn property JoueurConcret Joueur
         * 
         * \brief Le Joueur possédant cette unité.
         */
        JoueurConcret Joueur
        {
            get;
            set;
        }

        /**
         * \fn property TypeCase CaseCourante
         * 
         * \brief Permet de connaitre le type de case sur laquelle est stationnée cette unité.
         */
        BonusCase CaseCourante
        {
            get;
        }

        /**
         * \fn property int PV
         * 
         * \brief Les points de vie de cette unité.
         */
        int PV
        {
            get;
            set;
        }

        /**
         * \fn property int PtsGeneres
         * 
         * \brief Les points de vie de cette unité.
         */
        int PtsGeneres
        {
            get;
        }

        /**
         * \fn property int PtsDeplacement
         * 
         * \brief Les points de déplacement de cette unité.
         */
        int PtsDeplacement
        {
            get;
            set;
        }

        /**
         * \fn bool estAmie(Unite u)
         * 
         * \brief Vérifie si l'Unite en paramètre appartient au même joueur
         * 
         * \param[in] Unite u l'Unite a tester
         * 
         * \return true si l'Unite en paramètre appartient au même joueur, faux sinon.
         */
        bool estAmie(Unite u);

        /**
         * \fn int utiliserUnite(BonusCase c)
         * 
         * \brief Déplace l'Unite vers la Case passée en paramètre.
         * Si la case cible est occupée par un ennemi, lance un combat.
         * Déplace l'Unite si elle est victorieuse et s'il ne reste plus
         * d'ennemi sur la case cible.
         * 
         * \param[in] Case c la case cible du déplacement
         * 
         * \return true en cas de deplacement, false sinon
         */
        bool utiliserUnite(BonusCase c);

        /**
         * \fn void detruire()
         * 
         * \brief Tue l'Unite si elle n'a plus de points de vie.
         * Il faut donc retirer toutes les références vers cette Unite
         */
        void detruire();

        /**
         * \fn void deplacementOk(BonusCase caseCible)
         * 
         * \brief Vérifie si l'Unite peut se déplacer sur la case passée en paramètre.
         *
         * \param[in] BonusCase c la case cible
         * 
         * \return true si l'Unite est capable de se déplacer à cet endroit, false sinon
         */
        bool caseAccessible(BonusCase caseCible);
    }
}
