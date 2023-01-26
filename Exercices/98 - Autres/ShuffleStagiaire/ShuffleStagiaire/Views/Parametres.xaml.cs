using ShuffleStagiaire.Data.Models;
using ShuffleStagiaire.Data.Services;
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

namespace ShuffleStagiaire.Views
{
    /// <summary>
    /// Interaction logic for Parametres.xaml
    /// </summary>
    public partial class Parametres : Window
    {
        public Parametres()
        {
            InitializeComponent();
            RemplirGridStag();
            RemplirGridComp();
            DesactiverModSup();
        }

        private void RemplirGridStag()
        {
            dtgrdStagiaires.ItemsSource = null;
            dtgrdStagiaires.ItemsSource = StagiairesServices.ListingStagiaires;
            DesactiverModSup();
        }

        private void RemplirGridComp()
        {
            dtgrdComputers.ItemsSource = null;
            dtgrdComputers.ItemsSource = ComputersServices.ListingComp;
            DesactiverModSup();
        }

        private void btnStag_Click(object sender, RoutedEventArgs e)
        {
            string cible = ((Button)sender).Content.ToString();
            Stagiaires stag;
            if (dtgrdStagiaires.SelectedItem != null)
            {
                stag = (Stagiaires)dtgrdStagiaires.SelectedItem;
            }
            else
            {
                stag = new Stagiaires();
            }
            Window detailStag = new DetailsStagiaires(cible, stag);
            this.Opacity = 0.7;
            detailStag.ShowDialog();
            RemplirGridStag();
            this.Opacity = 1;
        }

        private void DesactiverModSup()
        {
            btnModifStagiaire.IsEnabled = false;
            btnSuppStagiaire.IsEnabled = false;
            btnModifOrdi.IsEnabled = false;
        }

        private void dtgrdStagiaires_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnModifStagiaire.IsEnabled = true;
            btnSuppStagiaire.IsEnabled = true;
            btnModifOrdi.IsEnabled = false;
        }

        private void btnComp_Click(object sender, RoutedEventArgs e)
        {
            string cible = ((Button)sender).Content.ToString();
            Computers ordi;
            if (dtgrdComputers.SelectedItem != null)
            {
                ordi = (Computers)dtgrdComputers.SelectedItem;
            }
            else
            {
                ordi = new Computers();
            }
            Window detailsOrdi = new DetailsComputers(cible, ordi);
            this.Opacity = 0.7;
            detailsOrdi.ShowDialog();
            RemplirGridComp();
            this.Opacity = 1;
        }

        private void dtgrdComputers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnModifOrdi.IsEnabled = true;
            btnModifStagiaire.IsEnabled = false;
            btnSuppStagiaire.IsEnabled = false;
        }
    }
}
