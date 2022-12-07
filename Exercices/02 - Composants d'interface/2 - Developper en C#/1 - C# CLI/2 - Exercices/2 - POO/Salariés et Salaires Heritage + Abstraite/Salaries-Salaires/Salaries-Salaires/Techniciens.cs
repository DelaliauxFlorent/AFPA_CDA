using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    class Techniciens : Salaries
    {
        private const int SALAIREBASE = 40;

        public Techniciens(string nomSalarie, string prenomSalarie, int ageSalarie, double salaire) : base(nomSalarie, prenomSalarie, ageSalarie, salaire)
        {
        }

        public override Double CalculSalaire()
        {
            return SALAIREBASE;
        }

    }
}
