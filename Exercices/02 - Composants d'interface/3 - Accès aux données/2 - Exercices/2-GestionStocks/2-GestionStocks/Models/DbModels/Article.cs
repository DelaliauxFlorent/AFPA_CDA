using System;
using System.Collections.Generic;

#nullable disable

namespace _2_GestionStocks.Models.DbModels
{
    public partial class Article
    {
        public int IdArticle { get; set; }
        public string LibelleArticle { get; set; }
        public int? QuantiteStockee { get; set; }
        public int IdCategorie { get; set; }

        public virtual Category Category { get; set; }
    }
}
