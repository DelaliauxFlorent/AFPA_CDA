using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    class Commerciaux : Salaries
    {
        public Commerciaux(string nomSalarie, string prenomSalarie, int ageSalarie, double salaire, int nbrePrime) : base(nomSalarie, prenomSalarie, ageSalarie, salaire)
        {
            NbrePrimes = nbrePrime;
        }

        public int NbrePrimes { get; set; }


    }
}
