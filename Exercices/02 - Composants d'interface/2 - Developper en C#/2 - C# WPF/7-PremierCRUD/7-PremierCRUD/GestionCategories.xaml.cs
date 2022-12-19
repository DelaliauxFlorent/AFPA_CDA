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
    /// Interaction logic for GestionCategories.xaml
    /// </summary>
    public partial class GestionCategories : Window
    {
        public GestionCategories()
        {
            InitializeComponent();
            CategorieService.RemplirGrid(this);
        }
        private void Row_DblClck(object sender, MouseButtonEventArgs e)
        {
            // On récupère le produit que l'on veut modifier
            DataGridRow row = sender as DataGridRow;
            Categories categ = (Categories)row.Item;
            // On instancie une fenêtre de détail en mode "Visualiser"
            DetailsCategorie detail = new DetailsCategorie(this, "Visualiser", categ);
            base.Opacity = 0.7;
            detail.ShowDialog();
            // On refresh() la DataGrid
            dtgdGrille.Items.Refresh();
            base.Opacity = 1;
        }

        /// <summary>
        /// Gestion de la demande d'ajout d'un produit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            // On instancie une fenêtre de détail en mode "Ajouter"
            DetailsCategorie fenetreAjout = new DetailsCategorie(this, "Ajouter");
            base.Opacity = 0.7;
            fenetreAjout.ShowDialog();
            // On refresh() la DataGrid
            dtgdGrille.Items.Refresh();
            base.Opacity = 1;
        }

        /// <summary>
        /// Gestion de la demande de suppression d'un produit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuppr_Click(object sender, RoutedEventArgs e)
        {
            if (dtgdGrille.SelectedItem != null)
            {
                // On récupère le produit que l'on veut supprimer
                Produits prodSuppr = (Produits)dtgdGrille.SelectedItem;
                // On instancie une fenêtre de détail en mode "Supprimer"
               // Details fenetreSuppr = new DetailsProduit(this, "Supprimer", prodSuppr);
                base.Opacity = 0.7;
                //fenetreSuppr.ShowDialog();
                // On refresh() la DataGrid
                dtgdGrille.Items.Refresh();
                base.Opacity = 1;
            }
        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            btnSuppr.IsEnabled = true;
            btnModif.IsEnabled = true;
        }

        private void DataGridRow_Unselected(object sender, RoutedEventArgs e)
        {
            btnSuppr.IsEnabled = false;
            btnModif.IsEnabled = false;
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            if (dtgdGrille.SelectedItem != null)
            {
                Categories categ = (Categories)dtgdGrille.SelectedItem;
                DetailsCategorie detail = new DetailsCategorie(this, "Modifier", categ);
                base.Opacity = 0.7;
                detail.ShowDialog();
                // On refresh() la DataGrid
                dtgdGrille.Items.Refresh();
                base.Opacity = 1;
            }
        }
    }
}
