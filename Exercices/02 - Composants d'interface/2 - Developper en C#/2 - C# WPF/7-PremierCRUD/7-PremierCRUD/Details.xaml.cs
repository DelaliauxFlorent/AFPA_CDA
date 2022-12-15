using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace _7_PremierCRUD
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {

        public Details(Produits prod)
        {
            InitializeComponent();
            valChamp1.Content = prod.IdProduit;
            valChamp2.Text = prod.LibelleProduit;
            valChamp3.Text = prod.Quantite.ToString();
        }
    }
}
