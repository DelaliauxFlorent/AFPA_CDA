using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Dtos
{
    public class ContentDTO
    {
        public virtual CommandDTOBase Command { get; set; }
        public int QuantityContent { get; set; }
        public virtual ProductDTO Product { get; set; }
    }

    public class ContentDTOForCommands
    {
        public int QuantityContent { get; set; }
        public String NameProduct { get; set; }
        public int PricePoduct { get; set; }
    }

    public class ContentDTOForProduits
    {
        public int QuantityContent { get; set; }
        public String AddressDeliv { get; set; }
    }
}
