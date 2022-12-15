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
        private const string PathListProd = "../../ListeProduits.json";

        public MainWindow()
        {
            InitializeComponent();
            RemplirGrid();
        }

        public void RemplirGrid()
        {
            dtgdGrille.ItemsSource = CreerListeFile();
        }

        private List<Produits> CreerListe()
        {
            List<Produits> liste = new List<Produits>();

            for (int i = 1; i < 15; i++)
            {
                Produits p = new Produits(i, "Produit" + i, i * 2);
                liste.Add(p);
            }
            liste.Dump();
            return liste;
        }

        private List<Produits> CreerListeFile()
        {
            using (StreamReader r = new StreamReader(PathListProd))
            {
                string json = r.ReadToEnd();
                List<Produits> listProduits = JsonConvert.DeserializeObject<List<Produits>>(json);
                return listProduits;
            }
        }

        private void Row_DblClck(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Produits prod = (Produits)row.Item;
            Details detail = new Details(prod);
            base.Opacity = 0.7;
            detail.ShowDialog();
            base.Opacity = 1;
        }
    }
}
