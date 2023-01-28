using ShuffleStagiaire.Data.Models;
using ShuffleStagiaire.Data.Services;
using ShuffleStagiaire.Tools;
using ShuffleStagiaire.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShuffleStagiaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Salles salle = new Salles(16);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string cible = ((Button)sender).Content.ToString();
            this.Opacity = 0.7;
            Window newFenetre;
            switch (cible)
            {
                case "Paramétrage":
                    newFenetre = new Parametres();
                    newFenetre.ShowDialog();
                    break;
                case "Mélange":
                    int nbreOrdi = ComputersServices.ListeOrdiInUse().Count();
                    int nbreStag = StagiairesServices.nbreStagiaire;
                    if (nbreOrdi >= nbreStag)
                    {
                        List<Stagiaires> shuffleListStag = new List<Stagiaires>(StagiairesServices.ListingStagiaires);
                        List<Computers> shuffleListOrdi = ComputersServices.ListeOrdiInUse();
                        Outils.Shuffle(shuffleListStag);
                        Outils.Shuffle(shuffleListOrdi);
                        ComputersServices.ResetSatgiairesComputers();
                        for (int i = 0; i < Math.Min(shuffleListStag.Count(), shuffleListOrdi.Count()); i++)
                        {
                            ComputersServices.ListingComp.Find(o => o.Position == shuffleListOrdi[i].Position).Stagiaire = shuffleListStag[i];
                        }
                        ComputersServices.ModifierOrdi();
                    }
                    else
                    {
                        MessageBox.Show("Erreur! Il n'y a pas assez d'ordinateurs déclarés comme \"Actif\" pour tous les stagiaires...\nVeuillez en rajouter.", "Trop de stagiaires", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;
                case "Visualisation":
                    newFenetre = new VisuSalle();
                    newFenetre.ShowDialog();
                    break;
            }
            this.Opacity = 1;
        }

    }
}
