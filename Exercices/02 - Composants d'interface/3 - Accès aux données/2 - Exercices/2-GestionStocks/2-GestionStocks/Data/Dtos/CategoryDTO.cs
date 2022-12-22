using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Data.Dtos
{
    public class CategoryDTO
    {
        public string LibelleCategorie { get; set; }
    }
    public class CategoriesDTOIn
    {
        public string LibelleCategorie { get; set; }
        public int IdTypeProduit { get; set; }
    }
}
