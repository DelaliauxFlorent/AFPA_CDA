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

        public MainWindow()
        {
            InitializeComponent();
            ProduitService.RemplirGrid(PathListProd, this);
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

    }
}
