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

        public DetailsComputers(string action, Computers ordi)
        {
            InitializeComponent();
            _ordi = ordi;
            this.Title = action + " un ordinateur";
            lblDetailsComputers.Content = action + " un ordinateur";
            btnActionDetComp.Content = action;
            RemplirComboBox();
        }

        private void RemplirChamps()
        {
            txtbxPosition.Text = _ordi.Position.ToString();
            txtbxPatrimoine.Text = _ordi.Patrimoine.ToString();
            txtbxIP.Text = _ordi.IP;
        }

        private void RemplirComboBox()
        {
            cmbxStag.ItemsSource = StagiairesServices.ListingStagiaires;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
