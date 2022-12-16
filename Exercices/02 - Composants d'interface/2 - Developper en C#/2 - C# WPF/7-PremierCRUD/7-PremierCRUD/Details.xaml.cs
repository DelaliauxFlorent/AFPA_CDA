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
            RemplirChamps(prod);
            fenetreParente = w;
        }

        private void RemplirChamps(Produits p)
        {
            valChamp1.Content = p.IdProduit;
            valChamp2.Text = p.LibelleProduit;
            valChamp3.Text = p.Quantite.ToString();
        }

        /// <summary>
        /// Si on veut annuler, on ferme simplement la fenêtre sans rien faire d'autre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnul_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gestion de la tentative de modification d'une entrée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            //on change pas l'ID et le libelle peut être "n'importe quoi"
            // Mais la quantité doit être un entier
            if (int.TryParse(valChamp3.Text, out int qte))
            {
                // Si c'est bien le cas, on peut dire à la fenêtre parente de réaliser les modifs voulues
                Produits newProd = new Produits((Int32)valChamp1.Content, valChamp2.Text, qte);
                fenetreParente.MAJRetour(newProd);
                this.Close();
            }
            else
            {
                // Sinon, on informe l'utilisateur du problème et c'est tous
                MessageBox.Show("Le champ \"Quantité\" doit être en entier!", "Erreur de format", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
