using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Dtos
{
    public class ContentDTO
    {
        public int IdProduct { get; set; }
        public int IdCommand { get; set; }
        public int QuantityContent { get; set; }

        public virtual CommandDTO Command { get; set; }
        public virtual ProductDTO Product { get; set; }
    }

    public class ContentDTOForCommands
    {
        public String NameProduct { get; set; }
        public int PricePoduct { get; set; }
        public int QuantityContent { get; set; }
    }
}
