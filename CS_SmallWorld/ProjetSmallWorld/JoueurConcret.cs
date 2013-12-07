using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    /**
     * \class JoueurConcret
     * 
     * \brief implémentation de la classe Joueur
     */
    public class JoueurConcret : Joueur
    {
        private string _name;
        private int _score;
        private Peuple _peuple;
        private List<Unite> _troupes;
        private int _nbUniteRestantes;
        /**
         * \fn Constructeur de la classe
         */
        public JoueurConcret(string name, int peuple, BonusCase startCase, int nbUnite)
        {
            _name = name;
            _score = 0;
            _troupes = new List<Unite>();
            _peuple = donnerPeuple(peuple, startCase);         
            _nbUniteRestantes = nbUnite;

        }

        /** cf interface */
        public string Name
        {
            get { return _name; }
        }

        /** cf interface */
        public int Score
        {
            get { return _score; }
        }

        /** cf interface */
        public Peuple Peuple
        {
            get { return _peuple; }
        }

        /** cf interface */
        public void ajouterUneUnite(Unite u)
        {
            _troupes.Add(u);
        }

        /** cf interface */
        public void retirerUneUnite(Unite u)
        {
            if (_troupes.Contains(u))
                _troupes.Remove(u);
            else
                throw new InvalidOperationException("L'unite passée en paramètre ne peut pas être retirée car "
                    + "elle ne fait pas partie des troupes de ce joueur");
        }

        //public Unite getUneUnite(int numUnite)
        //{
        //    return _troupes.ElementAt(numUnite);
        //}

        /**
         * \fn Peuple donnerPeuple(int peuple, TypeCase startCase)
         * 
         * \brief Traduit l'int peuple passé en paramètre en Peuple et indique la Case de départ pour les unités.
         * 
         * \param[in] int peuple le numéro correspondant au Peuple à créer
         * 
         * \param[in] TypeCase startCase la case de départ pour ce joueur, donc pour ce peuple
         */
        private Peuple donnerPeuple(int peuple, BonusCase startCase)
        {
            switch(peuple)
            {
                case 1:
                    return new PeupleGauloisConcret(this, startCase, _nbUniteRestantes);
                case 2:
                    return new PeupleNainConcret(this, startCase, _nbUniteRestantes);
                case 3:
                    return new PeupleVikingConcret(this, startCase, _nbUniteRestantes);
                default:
                    throw new InvalidOperationException("le numero de Peuple est invalide.");
            }
        }

        /** cf interface */
        public void compterScore()
        {
            int score =0;
            foreach (Unite u in _troupes)
                score += u.PtsGeneres;

            _score += score;
        }
    }
}
