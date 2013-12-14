using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface Joueur
     * 
     * \brief Un joueur du SmallWorld.
     */
    public interface Joueur
    {
        /**
         * \fn property Name (lecture seule)
         * 
         * \brief Le nom du joueur
         * 
         */
        string Name
        {
            get;
        }

        /**
         * \fn property Peuple (lecture seule)
         * 
         * \brief Le Peuple contrôlé par le joueur
         * 
         */
        Peuple Peuple
        {
            get;
        }

        /**
         * \fn property Score (lecture-écriture)
         * 
         * \brief Les points accumulés par le joueur.
         * 
         */
        int Score
        {
            get;
        }

        /**
         * \fn property Troupes (lecture seule)
         * 
         * \brief Les troupes du joueur.
         * 
         */
        List<Unite> Troupes
        {
            get;
        }

        /**
         * \fn void ajouteUneUnite(Unite u)
         * 
         * \brief Ajoute une Unite aux troupes du joueur.
         * 
         * \param[in] Unite u l'Unite à ajouter
         */
        void ajouterUneUnite(Unite u);

        /**
         * \fn void retirerUneUnite(Unite u)
         * 
         * \brief Retirn une Unite aux troupes du joueur.
         * 
         * \param[in] Unite u l'Unite à retirer
         */
        void retirerUneUnite(Unite u);

        
        //Unite getUneUnite(int numUnite);

        /**
         * \fn void compterScore()
         * 
         * \brief Compte le score marqué par le joueur durant le tour courant et le rajoute au Score.
         * 
         */
        void compterScore();

        //TODO: ajouter couleur
    }
}
