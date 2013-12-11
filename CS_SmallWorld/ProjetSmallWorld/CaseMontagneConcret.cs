using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public class CaseMontagneConcret : TypeCaseAbstrait, CaseMontagne
    {
        static List<CaseMontagne> _allMontagnes;

        public List<CaseMontagne> AllMontagnes
        {
            get { return _allMontagnes;}
        }

        public CaseMontagneConcret()
        {
            if (_allMontagnes == null)
                _allMontagnes = new List<CaseMontagne>();

            ajouterMontagne();
        }

        public void ajouterMontagne()
        {
            _allMontagnes.Add(this);
        }
    }
}
