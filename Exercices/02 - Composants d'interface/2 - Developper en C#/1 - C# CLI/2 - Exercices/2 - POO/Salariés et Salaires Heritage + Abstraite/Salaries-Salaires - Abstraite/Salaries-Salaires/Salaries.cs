using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    abstract class Salaries
    {
        public Salaries(string nomSalarie, string prenomSalarie, int ageSalarie, double salaire)
        {
            NomSalarie = nomSalarie;
            PrenomSalarie = prenomSalarie;
            AgeSalarie = ageSalarie;
            Salaire = salaire;
        }

        public String NomSalarie { get; set; }
        public String PrenomSalarie { get; set; }
        public int AgeSalarie { get; set; }
        public Double Salaire { get; set; }

        public override string ToString()
        {
            String origine = base.GetType().Name;
            return "Salaries."+origine+"\tNom : "+NomSalarie+"\t Prenom : "+PrenomSalarie+"\t Age : "+AgeSalarie+"\t Salaire : "+CalculSalaire();
        }

        abstract public virtual Double CalculSalaire()
        {
            return Salaire;
        }

    }
}
