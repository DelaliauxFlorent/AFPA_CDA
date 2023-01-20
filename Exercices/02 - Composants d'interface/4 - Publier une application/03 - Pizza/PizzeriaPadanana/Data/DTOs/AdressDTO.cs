using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.DTOs
{
    /// <summary>
    /// Classe AdressDTO
    /// </summary>
    public class AdressDTO
    {
        public string Adresse { get; set; }
        public string ComplementAdresse { get; set; }
        public string CdPost { get; set; }
        public string Ville { get; set; }
        public int IdCompte { get; set; }

        public virtual Compte IdCompteNavigation { get; set; }
    }
}
