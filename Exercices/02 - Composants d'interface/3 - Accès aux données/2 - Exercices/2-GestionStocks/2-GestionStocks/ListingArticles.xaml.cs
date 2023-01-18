using _2_GestionStocks.Controller;
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
using System.Windows.Shapes;

namespace _2_GestionStocks
{
    /// <summary>
    /// Interaction logic for ListingArticles.xaml
    /// </summary>
    public partial class ListingArticles : Window
    {
        public ListingArticles(MyDbContext _context)
        {
            InitializeComponent();
            ArticlesController _control = new ArticlesController(_context);
            dtgrdListingArticles.ItemsSource = _control.GetAllArticles();
        }
    }
}
