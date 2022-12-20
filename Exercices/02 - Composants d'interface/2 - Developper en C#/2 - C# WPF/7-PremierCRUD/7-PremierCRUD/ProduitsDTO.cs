using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    public class ProduitsDTO
    {
        public int IdProduit { get; set; }
        public String LibelleProduit { get; set; }
        public String NumeroProduit { get; set; }
        public int Quantite { get; set; }
        public int IdCategorie { get; set; }
        public String LibelleCategorie { get; set; }

        public ProduitsDTO(int idProduit, string libelleProduit, string numero, int quantite, int idCategorie, String lblCateg)
        {
            IdProduit = idProduit;
            LibelleProduit = libelleProduit;
            NumeroProduit = numero;
            Quantite = quantite;
            IdCategorie = idCategorie;
            LibelleCategorie = lblCateg;
        }

        public ProduitsDTO(Produits prod)
        {
            IdProduit = prod.IdProduit;
            LibelleProduit = prod.LibelleProduit;
            NumeroProduit = prod.NumeroProduit;
            Quantite = prod.Quantite;
            if (CategorieService.FindById(prod.IdCategorie).LibelleCategorie!="")
            {
                IdCategorie = prod.IdCategorie;
                LibelleCategorie = CategorieService.FindById(prod.IdCategorie).LibelleCategorie;
            }
            else
            {
                LibelleCategorie = "Aucune catégorie";
            }
        }

        public ProduitsDTO(int idProduit)
        {
            IdProduit = idProduit;
        }

        public ProduitsDTO()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj as ProduitsDTO == null)
            {
                return false;
            }
            if (this.IdProduit == ((ProduitsDTO)obj).IdProduit)
            {
                return true;
            }
            return false;
        }
    }
}
