using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
     public class Categories
    {
        public int IdCategorie { get; set; }
        public String LibelleCategorie { get; set; }

        public Categories(int idCategorie, string libelleCategorie)
        {
            IdCategorie = idCategorie;
            LibelleCategorie = libelleCategorie;
        }


        public Categories(int idCategorie)
        {
            IdCategorie = idCategorie;
        }

        public Categories()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj as Categories == null)
            {
                return false;
            }
            if (this.IdCategorie == ((Categories)obj).IdCategorie)
            {
                return true;
            }
            return false;
        }
    }

}
