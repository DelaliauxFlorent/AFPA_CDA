using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Applicationstva
    {
        public int IdApplicationTva { get; set; }
        public int? IdProduit { get; set; }
        public int? IdTva { get; set; }
        public DateTime DateTva { get; set; }

        public virtual Produit IdProduitNavigation { get; set; }
        public virtual Tva IdTvaNavigation { get; set; }
    }
}
