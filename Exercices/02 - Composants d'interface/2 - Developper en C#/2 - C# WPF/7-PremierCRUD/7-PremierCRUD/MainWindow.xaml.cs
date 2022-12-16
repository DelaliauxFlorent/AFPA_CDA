using DemoEF.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _7_PremierCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string PathListProd = "../../ListeProduits.json";
        public List<Produits> listingProduits = new List<Produits>();

        public MainWindow()
        {
            InitializeComponent();
            RemplirGrid();
        }

        /// <summary>
        /// Remplissage de la DataGrid
        /// </summary>
        public void RemplirGrid()
        {
            //CreerListe();
            //CreerListeFileJSON();
            listingProduits.Clear();
            listingProduits.AddRange(ProduitService.CreerListeFileJSON(PathListProd));
            dtgdGrille.ItemsSource = listingProduits;
        }

        /// <summary>
        /// Création de la liste de façon automatique
        /// </summary>
        private void CreerListe()
        {
            List<Produits> liste = new List<Produits>();

            for (int i = 1; i < 15; i++)
            {
                Produits p = new Produits(i, "Produit" + i, i * 2);
                liste.Add(p);
            }
            //liste.Dump();
            listingProduits.Clear();
            listingProduits.AddRange(liste);
        }

        /// <summary>
        /// Création de la liste à partir d'un fichier JSON
        /// </summary>
        private void CreerListeFileJSON()
        {
            using (StreamReader r = new StreamReader(PathListProd))
            {
                // Met le contenu du JSON dans la chaîne de caractères "json"
                string json = r.ReadToEnd();
                // Converti la chaîne en une liste de produits appelé "listProduits"
                List<Produits> listProduits = JsonConvert.DeserializeObject<List<Produits>>(json);
                // Vide la liste "interne" pour être sur une base saine
                listingProduits.Clear();
                // Rempli la liste "interne" avec la liste tirée du fichier JSON
                listingProduits.AddRange(listProduits);
            }
        }

        /// <summary>
        /// Mise à jour du fichier JSON
        /// </summary>
        private void UpdateListeFileJSON()
        {
            using (StreamWriter ecrire = new StreamWriter(PathListProd, false))
            {
                string json = JsonConvert.SerializeObject(listingProduits);
                ecrire.Write(json);
            }
        }

        /// <summary>
        /// Gestion du double clique sur une ligne de la DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Row_DblClck(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Produits prod = (Produits)row.Item;
            Details detail = new Details(this, prod);
            base.Opacity = 0.7;
            detail.ShowDialog();
            base.Opacity = 1;
        }

        /// <summary>
        /// Mise à jour des valeurs
        /// </summary>
        /// <param name="prodRetour"></param>
        public void MAJRetour(Produits prodRetour)
        {
            ((Produits)dtgdGrille.SelectedItem).LibelleProduit = prodRetour.LibelleProduit;
            ((Produits)dtgdGrille.SelectedItem).Quantite = prodRetour.Quantite;
            dtgdGrille.Items.Refresh();
            UpdateListeFileJSON();
        }
    }
}
