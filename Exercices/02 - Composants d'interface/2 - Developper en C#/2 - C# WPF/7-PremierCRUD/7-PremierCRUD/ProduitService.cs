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
        public const string PathListProd = "../../ListeProduits.json";

        /// <summary>
        /// On remplit la liste des produits en passant par un des CreerListe, puis on peuple la DataGrid avec.
        /// </summary>
        /// <param name="fichier">Chemin d'accès au fichier qu'on passera en argument pour la création de la liste</param>
        /// <param name="w"></param>
        public static void RemplirGrid(GestionProduits w)
        {
            ListingProduits = new List<Produits>();
            ListingProduits.AddRange(CreerListeFileJSON());
            w.dtgdGrille.ItemsSource = ListingProduits;
        }

        /// <summary>
        /// Récupération d'une liste de produit à partir d'un JSON
        /// </summary>
        /// <param name="fichier">Chemin d'accès du fichier que FichierJson.LireJSON() devra lire</param>
        /// <returns></returns>
        public static List<Produits> CreerListeFileJSON()
        {
            String json = FichierJson.LireJSON();
            List<Produits> listProduits = JsonConvert.DeserializeObject<List<Produits>>(json);
            return listProduits;
        }

        /// <summary>
        /// Création d'une liste de produit de façon automatique
        /// </summary>
        public static List<Produits> CreerListe()
        {
            List<Produits> liste = new List<Produits>();

            for (int i = 1; i < 15; i++)
            {
                String j = "";
                if (i < 10)
                {
                    j = "0";
                }
                Produits p = new Produits(i, "Produit" + i, "20221216060" + j + i, i * 2);
                liste.Add(p);
            }
            liste.Dump();// Utilisé pour générer un JSON pour les tests
            return liste;
        }

        /// <summary>
        /// Mise à jour d'un fichier JSON avec les nouvelles données
        /// </summary>
        /// <param name="prodModif">Le produit que l'on veut modifier</param>
        /// <param name="lbl">Son nouveau "Libelle"</param>
        /// <param name="num">Son nouveau "Numéro"</param>
        /// <param name="qte">Sa nouvelle "Quantité"</param>
        /// <param name="fichier">Le chemin d'accès du fichier à mettre à jour</param>
        public static void ModifierProduit(Produits prodModif,String lbl, String num, int qte)
        {
            prodModif.LibelleProduit= lbl;
            prodModif.NumeroProduit=num;
            prodModif.Quantite=qte;
            string json = JsonConvert.SerializeObject(ListingProduits);
            FichierJson.UpdateListeFileJSON(json);
        }

        /// <summary>
        /// Ajout d'un produit dans un fichier JSON
        /// </summary>
        /// <param name="prodAjout">Le nouveau produit à ajouter à la liste et au fichier</param>
        /// <param name="fichier">Le chemin d'accès du fichier à mettre à jour</param>
        public static void AjouterProduit(Produits prodAjout)
        {
            ListingProduits.Add(prodAjout);
            string json = JsonConvert.SerializeObject(ListingProduits);
            FichierJson.UpdateListeFileJSON(json);
        }

        /// <summary>
        /// Suppression d'un produit dans un fichier JSON
        /// </summary>
        /// <param name="prodSuppr">Le produit à supprimer</param>
        /// <param name="fichier">Le chemin d'accès du fichier à mettre à jour<param>
        public static void SupprimerProduit(Produits prodSuppr)
        {
            ListingProduits.Remove(prodSuppr);
            string json = JsonConvert.SerializeObject(ListingProduits);
            FichierJson.UpdateListeFileJSON(json);
        }

        public static Produits FindById(int iD)
        {
            return ListingProduits.Find(x => x.IdProduit == iD);
        }
    }
}
