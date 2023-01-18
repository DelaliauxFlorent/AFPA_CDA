using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Adress
    {
        public int IdAdresse { get; set; }
        public string Adresse { get; set; }
        public string ComplementAdresse { get; set; }
        public string CdPost { get; set; }
        public string Ville { get; set; }
        public int IdCompte { get; set; }

        public virtual Compte IdCompteNavigation { get; set; }
    }
}
