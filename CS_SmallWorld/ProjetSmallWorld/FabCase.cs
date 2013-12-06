using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class interface FabCase
     * 
     * \brief Fabrique de Case
     * */
    public interface FabCase
    {
        /**
         * \fn property CaseMontagneConcret CaseMontagne
         * 
         * \brief une CaseMontagneConcret pour le poids-mouche
         * */
        CaseMontagneConcret CaseMontagne
        {
            get;
        }

        /**
         * \fn property CaseForetConcret CaseForet
         * 
         * \brief une CaseForetConcret pour le poids-mouche
         */
        CaseForetConcret CaseForet
        {
            get;
        }

        /**
         * \fn property CasePlaineeConcret CasePlaine
         * 
         * \brief une CasePlaineConcret pour le poids-mouche
         */
        CasePlaineConcret CasePlaine
        {
            get;
        }

        /**
         * \fn property CaseEauConcret CaseEau
         * 
         * \brief une CaseEauConcret pour le poids-mouche
         */
        CaseEauConcret CaseEau
        {
            get;
        }

        /**
         * \fn property CaseDesertConcret CaseDesert
         * 
         * \brief une CaseDesertConcret pour le poids-mouche
         */
        CaseDesertConcret CaseDesert
        {
            get;
        }
    }
}
