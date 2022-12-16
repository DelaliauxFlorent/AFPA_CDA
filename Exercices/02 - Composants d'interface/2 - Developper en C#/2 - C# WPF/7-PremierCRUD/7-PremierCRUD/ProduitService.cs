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
            listingProduits.AddRange(ProduitService.CreerListeFileJSON(fichier));
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
                Produits p = new Produits(i, "Produit" + i, i * 2);
                liste.Add(p);
            }
            return liste;
        }

        /// <summary>
        /// Mise à jour des valeurs
        /// </summary>
        /// <param name="prodRetour"></param>
        public static void MAJRetour(Produits prodRetour,int indexP, String fichier, MainWindow w)
        {
            listingProduits.RemoveAt(indexP);
            listingProduits.Insert(indexP, prodRetour);
            FichierJSON.UpdateListeFileJSON(fichier);
        }

    }
}
