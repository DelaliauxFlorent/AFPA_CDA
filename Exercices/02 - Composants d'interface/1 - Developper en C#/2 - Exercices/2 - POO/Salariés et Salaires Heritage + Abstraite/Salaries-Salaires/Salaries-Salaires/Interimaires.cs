using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    class Interimaires : Techniciens
    {
        private const Double VHEURE = 0.5; 
        public Interimaires(string nomSalarie, string prenomSalarie, int ageSalarie, double salaire, int nbreHeures) : base(nomSalarie, prenomSalarie, ageSalarie, salaire)
        {
            NbreHeures = nbreHeures;
        }

        public int NbreHeures { get; set; }

        public override Double CalculSalaire()
        {
            return VHEURE * NbreHeures;
        }
    }
}
