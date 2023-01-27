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
    /// Interaction logic for VisuSalle.xaml
    /// </summary>
    public partial class VisuSalle : Window
    {
        public VisuSalle()
        {
            InitializeComponent();
            PlacerStagiaires();
        }

        private void PlacerStagiaires()
        {
            Label lbl;
            for (int n = 1; n <= 16; n++)
            {
                lbl = (Label)FindName($"lblPos{n}");
                lbl.Content = ComputersServices.ListingComp[n-1].Stagiaire.Nom;
            }
        }
    }
}
