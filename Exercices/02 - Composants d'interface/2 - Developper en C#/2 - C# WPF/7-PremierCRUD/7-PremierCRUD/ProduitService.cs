using DemoEF.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    class ProduitService
    {

        public static List<Produits> listingProduits = new List<Produits>();

        /// <summary>
        /// Remplissage de la DataGrid
        /// </summary>
        public static void RemplirGrid(String fichier, MainWindow w)
        {
            listingProduits.Clear();
            //listingProduits.AddRange(CreerListe());
            listingProduits.AddRange(CreerListeFileJSON(fichier));
            w.dtgdGrille.ItemsSource = listingProduits;
        }

        public static List<Produits> CreerListeFileJSON(String fichier)
        {
            String json = FichierJSON.LireJSON(fichier);
            List<Produits> listProduits = JsonConvert.DeserializeObject<List<Produits>>(json);
            return listProduits;
        }

        /// <summary>
        /// Création de la liste de façon automatique
        /// </summary>
        public static List<Produits> CreerListe()
        {
            List<Produits> liste = new List<Produits>();

            for (int i = 1; i < 15; i++)
            {
                String j="";
                if (i < 10)
                {
                    j = "0";
                }
                Produits p = new Produits(i, "Produit" + i,"20221216060"+j+i, i * 2);
                liste.Add(p);
            }
            liste.Dump();
            return liste;
        }

        /// <summary>
        /// Mise à jour des valeurs
        /// </summary>
        /// <param name="prodRetour"></param>
        public static void ModifierListe(Produits prodRetour,int indexP, String fichier)
        {
            listingProduits.RemoveAt(indexP);
            listingProduits.Insert(indexP, prodRetour);
            FichierJSON.UpdateListeFileJSON(fichier);
        }

        public static void AjouterListe(Produits prodRetour, String fichier)
        {
            listingProduits.Add(prodRetour);
            FichierJSON.UpdateListeFileJSON(fichier);
        }

    }
}
