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
                    _stag.IdStagiaire = StagiairesServices.ListingStagiaires[StagiairesServices.ListingStagiaires.Count-1].IdStagiaire+1;
                    RemplirObjet();
                    StagiairesServices.AjouterStagiaire(_stag);
                    break;
                case "Modifier":
                    RemplirObjet();
                    StagiairesServices.ModifierStagiaire(_stag);
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
    }
}
