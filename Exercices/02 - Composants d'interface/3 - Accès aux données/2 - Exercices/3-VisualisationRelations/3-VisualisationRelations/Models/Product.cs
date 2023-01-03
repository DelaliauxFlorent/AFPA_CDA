using System;
using System.Collections.Generic;

#nullable disable

namespace _3_VisualisationRelations.Models
{
    public partial class Product
    {
        public Product()
        {
            Contents = new HashSet<Content>();
        }

        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
    }
}
