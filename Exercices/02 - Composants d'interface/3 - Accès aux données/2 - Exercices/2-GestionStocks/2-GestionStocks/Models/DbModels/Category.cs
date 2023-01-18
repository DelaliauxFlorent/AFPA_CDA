using System;
using System.Collections.Generic;

#nullable disable

namespace _2_GestionStocks.Models.DbModels
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public int IdCategorie { get; set; }
        public string LibelleCategorie { get; set; }
        public int IdTypeProduit { get; set; }

        public virtual Typesproduit TypeProduit { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
