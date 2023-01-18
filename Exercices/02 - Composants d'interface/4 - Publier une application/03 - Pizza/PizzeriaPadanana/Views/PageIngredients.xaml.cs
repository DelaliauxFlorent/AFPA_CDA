using PizzeriaPadanana.Data;
using PizzeriaPadanana.Data.DTOs;
using PizzeriaPadanana.Data.POCOs;
using PizzeriaPadanana.Data.Controllers;
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
using PizzeriaPadanana.Data.Services;
using PizzeriaPadanana.Data.Profiles;

namespace PizzeriaPadanana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageIngredients : Window
    {
        private PizzeriaDbContext _context;
        private IngredientsController _ingrController;
        public PageIngredients(PizzeriaDbContext context)
        {
            InitializeComponent();
            _context = context;
            _ingrController = new IngredientsController(_context);

            RemplirGrid();
        }

        public void RemplirGrid()
        {
            dtgrdListIngredients.ItemsSource = _ingrController.GetAllIngredients();
        }

    }
}
