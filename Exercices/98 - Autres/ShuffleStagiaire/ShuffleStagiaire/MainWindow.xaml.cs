using ShuffleStagiaire.Data.Models;
using ShuffleStagiaire.Data.Services;
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
            StagiairesServices.CreerListeFileJSON();
            ComputersServices.CreerListeFileJSON();
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
