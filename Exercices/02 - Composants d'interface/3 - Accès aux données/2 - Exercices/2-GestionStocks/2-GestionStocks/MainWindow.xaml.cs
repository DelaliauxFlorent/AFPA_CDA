using _2_GestionStocks.Data;
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

namespace _2_GestionStocks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyDbContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new MyDbContext();
        }

        private void btnListeArticles_Click(object sender, RoutedEventArgs e)
        {
            ListingArticles listArt = new ListingArticles(_context);
            base.Opacity =0.7;
            listArt.ShowDialog();
            base.Opacity = 1;
        }
    }
}
