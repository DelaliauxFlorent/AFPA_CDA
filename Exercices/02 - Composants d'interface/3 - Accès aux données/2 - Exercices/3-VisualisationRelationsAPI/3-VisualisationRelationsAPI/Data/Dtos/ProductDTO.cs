using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Dtos
{
    public class ProductDTO
    {

        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }

    }
    public class ProductDTOWithList
    {
        public ProductDTOWithList()
        {
            Contents = new HashSet<ContentDTOForProduits>();
        }

        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }

        public virtual ICollection<ContentDTOForProduits> Contents { get; set; }
    }
}
