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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGestionProduits_Click(object sender, RoutedEventArgs e)
        {
            GestionProduits gestProd = new GestionProduits();
            base.Opacity = 0.7;
            gestProd.ShowDialog();
            base.Opacity = 1;
        }
        private void btnGestionCategories_Click(object sender, RoutedEventArgs e)
        {
            GestionCategories gestCateg = new GestionCategories();
            base.Opacity = 0.7;
            gestCateg.ShowDialog();
            base.Opacity = 1;
        }
    }
}
