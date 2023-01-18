using PizzeriaPadanana.Data;
using PizzeriaPadanana.Data.POCOs;
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

namespace PizzeriaPadanana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PizzeriaDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new PizzeriaDbContext();
        }

        private void BtnInscription_Click(object sender, RoutedEventArgs e)
        {
            Inscription pageInscr = new Inscription();
            this.Opacity = 0.7;
            pageInscr.ShowDialog();
            this.Opacity = 1;
        }

        private void btnConnexionMW_Click(object sender, RoutedEventArgs e)
        {
            LogIn pageLog = new LogIn();
            this.Opacity = 0.7;
            pageLog.ShowDialog();
            this.Opacity = 1;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string cible = ((Button)sender).Name;
            this.Opacity = 0.7;
            switch (cible)
            {
                case "btnIngr":
                    PageIngredients pageIngr = new PageIngredients(_context);
                    pageIngr.ShowDialog();
                    break;
                case "btnTypeIngr":
                    PageTypeingredients pageTypeIngr = new PageTypeingredients(_context);
                    pageTypeIngr.ShowDialog();
                    break;
                default:
                    break;
            }
            this.Opacity = 1;
        }
    }
}
