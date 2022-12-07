using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    class Representants : Commerciaux
    {
        private const int SALAIREBASE = 50;
        private const int VPRIME = 5;
        private const int VDEPLA = 1;
        public Representants(string nomSalarie, string prenomSalarie, int ageSalarie, int nbrePrime, int nbreDepla) : base(nomSalarie, prenomSalarie, ageSalarie, SALAIREBASE, nbrePrime)
        {
            NbreDepla = nbreDepla;
        }

        public int NbreDepla { get; set; }

        public override double CalculSalaire()
        {
            return SALAIREBASE + (NbrePrimes * VPRIME) + (NbreDepla*VDEPLA);
        }

        public override string ToString()
        {
            return base.ToString()+"\tdont Salaire de "+SALAIREBASE+" + "+NbrePrimes+" primes à "+VPRIME+" + "+NbreDepla+" déplacements à "+VDEPLA;
        }
    }
}
