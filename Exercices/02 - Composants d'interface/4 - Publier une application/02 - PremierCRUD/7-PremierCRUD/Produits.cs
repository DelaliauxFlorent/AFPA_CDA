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
        public int IdCategorie { get; set; }

        public Produits(int idProduit, string libelleProduit, string numero, int quantite, int idCategorie)
        {
            IdProduit = idProduit;
            LibelleProduit = libelleProduit;
            NumeroProduit = numero;
            Quantite = quantite;
            IdCategorie = idCategorie;
        }

        public Produits(int idProduit)
        {
            IdProduit = idProduit;
        }
        public Produits(ProduitsDTO prodDTO)
        {
            IdProduit = prodDTO.IdProduit;
            LibelleProduit = prodDTO.LibelleProduit;
            NumeroProduit = prodDTO.NumeroProduit;
            Quantite = prodDTO.Quantite;
            IdCategorie = prodDTO.IdCategorie;
        }

        public Produits()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj as Produits == null)
            {
                return false;
            }
            if (this.IdProduit == ((Produits)obj).IdProduit)
            {
                return true;
            }
            return false;
        }
    }
}
