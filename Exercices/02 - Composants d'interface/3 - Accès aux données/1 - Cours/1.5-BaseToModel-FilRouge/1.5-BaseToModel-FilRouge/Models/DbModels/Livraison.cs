using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Livraison
    {
        public int IdLivraison { get; set; }
        public int? IdAdresse { get; set; }
        public int? IdCommande { get; set; }
        public int QuantiteLivraison { get; set; }
        public DateTime DateLivraison { get; set; }

        public virtual Adress IdAdresseNavigation { get; set; }
        public virtual Commande IdCommandeNavigation { get; set; }
    }
}
