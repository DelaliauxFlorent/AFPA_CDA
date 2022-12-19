using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    public class Produits
    {
        public int IdProduit { get; set; }
        public String LibelleProduit { get; set; }
        public String NumeroProduit { get; set; }
        public int Quantite { get; set; }

        public Produits(int idProduit, string libelleProduit, string numero, int quantite)
        {
            IdProduit = idProduit;
            LibelleProduit = libelleProduit;
            NumeroProduit = numero;
            Quantite = quantite;
        }
    }
}
