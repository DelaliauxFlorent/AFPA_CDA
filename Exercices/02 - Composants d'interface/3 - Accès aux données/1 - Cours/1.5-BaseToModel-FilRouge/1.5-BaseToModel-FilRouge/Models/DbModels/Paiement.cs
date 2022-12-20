using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Paiement
    {
        public int IdPaiement { get; set; }
        public int? IdReglement { get; set; }
        public int? IdCommande { get; set; }
        public DateTime DatePaiement { get; set; }
        public decimal MontantPaiement { get; set; }

        public virtual Commande IdCommandeNavigation { get; set; }
        public virtual Reglement IdReglementNavigation { get; set; }
    }
}
