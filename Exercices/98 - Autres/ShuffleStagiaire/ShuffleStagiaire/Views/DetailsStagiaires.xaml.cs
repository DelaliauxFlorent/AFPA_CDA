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
    /// Interaction logic for DetailsStagiaires.xaml
    /// </summary>
    public partial class DetailsStagiaires : Window
    {
        private Stagiaires _stag;
        public DetailsStagiaires(string action, Stagiaires stag)
        {
            InitializeComponent();
            this.Title= action + " un stagiaire";
            lblDetailsStagiaires.Content = action + " un stagiaire";
            btnActionDetStag.Content = action;
            _stag = stag;
            RemplirChamps();
            if (action == "Supprimer")
            {
                DesactiverChamps();
            }
            txtbxIdentifiantStag.Focus();
        }

        private void RemplirChamps()
        {
            txtbxIdentifiantStag.Text = _stag.Identifiant;
            txtbxNomStag.Text = _stag.Nom;
        }

        private void DesactiverChamps()
        {
            txtbxIdentifiantStag.IsEnabled = false;
            txtbxNomStag.IsEnabled = false;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string cible = ((Button)sender).Content.ToString();
            switch (cible)
            {
                case "Ajouter":
                    RemplirObjet();
                    int.TryParse(_stag.Identifiant.Split('-')[2], out int id);
                    _stag.IdStagiaire = id;
                    StagiairesServices.AjouterStagiaire(_stag);
                    break;
                case "Modifier":
                    Computers orditemp = ComputersServices.GetOrdiByStag(_stag);
                    RemplirObjet();
                    if (orditemp.Position != 0)
                    {
                        orditemp.Stagiaire = _stag;
                        ComputersServices.ModifierOrdi();
                    }
                    StagiairesServices.ModifierStagiaire();
                    break;
                case "Supprimer":
                    StagiairesServices.SupprimerStagiaire(_stag);
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void RemplirObjet()
        {
            _stag.Identifiant = txtbxIdentifiantStag.Text;
            _stag.Nom = txtbxNomStag.Text;
        }

        private void txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            txtbox.Select(txtbox.Text.Length, 0);
        }
    }
}
