using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Approvision
    {
        public int IdApprovision { get; set; }
        public int? IdProduit { get; set; }
        public int? IdFournisseur { get; set; }
        public string RefFournisseur { get; set; }

        public virtual Fournisseur IdFournisseurNavigation { get; set; }
        public virtual Produit IdProduitNavigation { get; set; }
    }
}
