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
        MainWindow fenetreParente;
        public Details(MainWindow w, Produits prod)
        {
            InitializeComponent();
            valChamp1.Content = prod.IdProduit;
            valChamp2.Text = prod.LibelleProduit;
            valChamp3.Text = prod.Quantite.ToString();
            fenetreParente = w;
        }

        private void btnAnnul_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(valChamp3.Text, out int qte))
            {
                Produits newProd = new Produits((Int32)valChamp1.Content, valChamp2.Text, qte);
                fenetreParente.MAJRetour(newProd);
                this.Close();
            }
            else
            {
                MessageBox.Show("Le champ \"Quantité\" doit être en entier!", "Erreur de format", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
