using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _7_PremierCRUD
{
    static class ProduitService
    {
        public static List<Produits> ListingProduits { get; set; }
        public static List<ProduitsDTO> ListingProduitsDTO { get; set; }
        public const string PathListProd = "./ListeProduits.json";

        /// <summary>
        /// On remplit la liste des produits en passant par un des CreerListe, puis on peuple la DataGrid avec.
        /// </summary>
        /// <param name="fichier">Chemin d'accès au fichier qu'on passera en argument pour la création de la liste</param>
        /// <param name="w"></param>
        public static void RemplirGrid(GestionProduits w)
        {
            CreerListeFileJSON();
            ListingProduitsDTO = new List<ProduitsDTO>();
            CategorieService.CreerListeFileJSON();
            for (int i = 0; i < ListingProduits.Count; i++)
            {
                ListingProduitsDTO.Add(new ProduitsDTO(ListingProduits[i]));
            }
            w.dtgdGrille.ItemsSource = ListingProduitsDTO;
        }

        /// <summary>
        /// Récupération d'une liste de produit à partir d'un JSON
        /// </summary>
        /// <param name="fichier">Chemin d'accès du fichier que FichierJson.LireJSON() devra lire</param>
        /// <returns></returns>
        public static void CreerListeFileJSON()
        {
            String json = FichierJson.LireJSON(PathListProd);
            ListingProduits = JsonConvert.DeserializeObject<List<Produits>>(json);
        }

        /// <summary>
        /// Création d'une liste de produit de façon automatique
        /// </summary>
        public static void CreerListe()
        {
            List<Produits> liste = new List<Produits>();

            for (int i = 1; i < 15; i++)
            {
                String j = "";
                if (i < 10)
                {
                    j = "0";
                }
                Produits p = new Produits(i, "Produit" + i, "20221216060" + j + i, i * 2,(i%5)+1);
                ListingProduits.Add(p);
            }
            liste.Dump();// Utilisé pour générer un JSON pour les tests
        }

        /// <summary>
        /// Mise à jour d'un fichier JSON avec les nouvelles données
        /// </summary>
        /// <param name="prodModif">Le produit que l'on veut modifier</param>
        /// <param name="lbl">Son nouveau "Libelle"</param>
        /// <param name="num">Son nouveau "Numéro"</param>
        /// <param name="qte">Sa nouvelle "Quantité"</param>
        /// <param name="fichier">Le chemin d'accès du fichier à mettre à jour</param>
        public static void ModifierProduit(ProduitsDTO prodDTOModif,String lbl, String num, int qte, int idCateg)
        {
            Produits prodModif = FindById(prodDTOModif.IdProduit);
            prodModif.LibelleProduit= lbl;
            prodModif.NumeroProduit=num;
            prodModif.Quantite=qte;
            prodModif.IdCategorie = idCateg;
            prodDTOModif.LibelleProduit = lbl;
            prodDTOModif.NumeroProduit = num;
            prodDTOModif.Quantite = qte;
            prodDTOModif.IdCategorie = idCateg;
            prodDTOModif.LibelleCategorie = ((Categories)CategorieService.FindById(idCateg)).LibelleCategorie;
            string json = JsonConvert.SerializeObject(ListingProduits);
            FichierJson.UpdateListeFileJSON(json, PathListProd);
        }

        /// <summary>
        /// Ajout d'un produit dans un fichier JSON
        /// </summary>
        /// <param name="prodAjout">Le nouveau produit à ajouter à la liste et au fichier</param>
        /// <param name="fichier">Le chemin d'accès du fichier à mettre à jour</param>
        public static void AjouterProduit(Produits prodAjout)
        {
            ListingProduits.Add(prodAjout);
            ProduitsDTO prodDTOAjout = new ProduitsDTO(prodAjout);
            ListingProduitsDTO.Add(prodDTOAjout);
            string json = JsonConvert.SerializeObject(ListingProduits);
            FichierJson.UpdateListeFileJSON(json, PathListProd);
        }

        /// <summary>
        /// Suppression d'un produit dans un fichier JSON
        /// </summary>
        /// <param name="prodSuppr">Le produit à supprimer</param>
        /// <param name="fichier">Le chemin d'accès du fichier à mettre à jour<param>
        public static void SupprimerProduit(ProduitsDTO prodDTOSuppr)
        {
            Produits prodSuppr = FindById(prodDTOSuppr.IdProduit);
            ListingProduits.Remove(prodSuppr);
            ListingProduitsDTO.Remove(prodDTOSuppr);
            string json = JsonConvert.SerializeObject(ListingProduits);
            FichierJson.UpdateListeFileJSON(json, PathListProd);
        }

        public static Produits FindById(int iD)
        {
            if(ListingProduits.Find(x => x.IdProduit == iD) != null)
            {
                return ListingProduits.Find(x => x.IdProduit == iD);
            }
            else
            {
                return new Produits();
            }
        }

        public static ProduitsDTO FindDTOById(int iD)
        {
            if (ListingProduits.Find(x => x.IdProduit == iD) != null)
            {
                return ListingProduitsDTO.Find(x => x.IdProduit == iD);
            }
            else
            {
                return new ProduitsDTO();
            }
        }
    }
}
