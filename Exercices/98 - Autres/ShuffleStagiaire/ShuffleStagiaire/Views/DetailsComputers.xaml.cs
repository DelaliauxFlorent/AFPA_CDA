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
    /// Interaction logic for DetailsComputers.xaml
    /// </summary>
    public partial class DetailsComputers : Window
    {
        private Computers _ordi;
        private Stagiaires _stag;

        public DetailsComputers(string action, Computers ordi)
        {
            InitializeComponent();
            _ordi = ordi;
            _stag = _ordi.Stagiaire;
            this.Title = action + " un ordinateur";
            lblDetailsComputers.Content = action + " un ordinateur";
            btnActionDetComp.Content = action;
            RemplirComboBox();
            RemplirChamps();
        }

        private void RemplirChamps()
        {
            lblPosition.Content = _ordi.Position.ToString();
            txtbxPatrimoine.Text = _ordi.Patrimoine.ToString();
            txtbxIP.Text = _ordi.IP;
        }

        private void RemplirComboBox()
        {
            cmbxStag.ItemsSource = StagiairesServices.ListingStagiaires;
            cmbxStag.SelectedItem = _ordi.Stagiaire;
        }
        private void DesactiverChamps()
        {
            txtbxPatrimoine.IsEnabled = false;
            txtbxIP.IsEnabled = false;
            cmbxStag.IsEnabled = false;
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string cible = ((Button)sender).Content.ToString();
            switch (cible)
            {
                case "Ajouter":
                    // On n'autorise pas les ajouts
                    break;
                case "Modifier":
                    Computers tempOrdi = ComputersServices.GetOrdiByStag((Stagiaires)cmbxStag.SelectedItem);
                    tempOrdi.Stagiaire = _stag;
                    RemplirObjet();
                    ComputersServices.ModifierOrdi(_ordi);
                    ComputersServices.ModifierOrdi(tempOrdi);
                    break;
                case "Supprimer":
                    // On n'autorise pas les suppressions
                    break;
                default:
                    break;
            }
            this.Close();
        }
        private void RemplirObjet()
        {
            int.TryParse(txtbxPatrimoine.Text, out int pat);
            _ordi.Patrimoine = pat;
            _ordi.IP = txtbxIP.Text;
            _ordi.Stagiaire = (Stagiaires)cmbxStag.SelectedItem;
        }
    }
}
