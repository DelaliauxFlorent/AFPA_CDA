using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    class Vendeurs : Commerciaux
    {
        private const int SALAIREBASE= 50;
        private const int VPRIME= 2;
        public Vendeurs(string nomSalarie, string prenomSalarie, int ageSalarie, int nbrePrime) : base(nomSalarie, prenomSalarie, ageSalarie, SALAIREBASE, nbrePrime)
        {
        }

        public override double CalculSalaire()
        {
            return SALAIREBASE + (NbrePrimes * VPRIME);
        }

        public override string ToString()
        {
            return base.ToString() + "\tdont Salaire de " + SALAIREBASE + " + " + NbrePrimes + " primes à " + VPRIME;
        }
    }
}
