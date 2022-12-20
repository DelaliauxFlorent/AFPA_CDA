using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Histoetatcom
    {
        public int IdHistoEtatCom { get; set; }
        public int? IdCommande { get; set; }
        public int? IdEtatCommande { get; set; }
        public DateTime DateEtatCommande { get; set; }

        public virtual Commande IdCommandeNavigation { get; set; }
        public virtual Etatscommande IdEtatCommandeNavigation { get; set; }
    }
}
