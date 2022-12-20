using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Lignescommande
    {
        public int IdLigneCommande { get; set; }
        public int? IdProduit { get; set; }
        public int? IdCommande { get; set; }
        public int QuantiteProduit { get; set; }

        public virtual Commande IdCommandeNavigation { get; set; }
        public virtual Produit IdProduitNavigation { get; set; }
    }
}
