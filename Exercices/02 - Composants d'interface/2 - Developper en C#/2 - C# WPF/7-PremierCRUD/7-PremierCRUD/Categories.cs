using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    class Categories
    {
        public int IdCategorie { get; set; }
        public String LibelleCategorie { get; set; }

        public Categories(int idCategorie, string libelleCategorie)
        {
            IdCategorie = idCategorie;
            LibelleCategorie = libelleCategorie;
        }
    }
}
