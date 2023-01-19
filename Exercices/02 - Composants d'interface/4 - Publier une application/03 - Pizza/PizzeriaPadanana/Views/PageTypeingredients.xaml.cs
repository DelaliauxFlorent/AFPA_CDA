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
using PizzeriaPadanana.Views;

namespace PizzeriaPadanana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageTypeingredients : Window
    {
        private PizzeriaDbContext _context;
        private TypeingredientsController _TypeIngrController;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        public PageTypeingredients(PizzeriaDbContext context)
        {
            InitializeComponent();
            _context = context;
            _TypeIngrController = new TypeingredientsController(_context);

            RemplirGrid();
        }

        /// <summary>
        /// Remplissage de la DataGrid
        /// </summary>
        private void RemplirGrid()
        {
            dtgrdListTypeIngredients.ItemsSource = _TypeIngrController.GetAllTypeingredients();
            btnModifTypeIng.IsEnabled = false;
            btnSupprTypeIng.IsEnabled = false;
        }

        /// <summary>
        /// Gestion des boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string action = ((Button)sender).Content.ToString();
            if (action == "Annuler")
            {
                this.Close();
            }
            else
            {
                TypeingredientDTO obj = (TypeingredientDTO)dtgrdListTypeIngredients.SelectedItem;
                if (action == "Ajouter")
                {
                    obj = new TypeingredientDTO();
                }
                Window fti = new FormulaireTypesIngredients(action, obj, _context);
                this.Opacity = 0.7;
                fti.ShowDialog();
                this.Opacity = 1;
                RemplirGrid();
            }
        }

        /// <summary>
        /// Gestion du changement de sélection d'un élément de la DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdListTypeIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnModifTypeIng.IsEnabled = true;
            btnSupprTypeIng.IsEnabled = true;
        }
    }
}
