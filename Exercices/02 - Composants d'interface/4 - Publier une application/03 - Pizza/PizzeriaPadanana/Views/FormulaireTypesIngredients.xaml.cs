using PizzeriaPadanana.Data;
using PizzeriaPadanana.Data.Controllers;
using PizzeriaPadanana.Data.DTOs;
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

namespace PizzeriaPadanana.Views
{
    /// <summary>
    /// Interaction logic for FormulaireTypesIngredients.xaml
    /// </summary>
    public partial class FormulaireTypesIngredients : Window
    {
        private string _action;
        private TypeingredientDTO _obj;
        private TypeingredientsController _controller;
        private PizzeriaDbContext _context;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="action">Action voulu (ajout, modification, suppression)</param>
        /// <param name="obj">Élément sur lequel on veut agir</param>
        /// <param name="context">Context</param>
        public FormulaireTypesIngredients(string action, TypeingredientDTO obj, PizzeriaDbContext context)
        {
            InitializeComponent();
            _action = action;
            _obj = obj;
            _context = context;
            _controller = new TypeingredientsController(_context);
            this.Title = _action + " un type d'ingrédient";
            lblTitreFormTypeIngr.Content = _action+" un type d'ingrédient";
            btnActionFormTypeIngr.Content = _action;
            switch (_action)
            {
                case "Modifier":
                    RemplirChamps();
                    break;
                case "Supprimer":
                    RemplirChamps();
                    DesactiverChamps();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gestion des boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string cible = ((Button)sender).Content.ToString();
            if (txbxNomTypeIngredientForm.Text == "" || txbxPrixTypeIngredientForm.Text == "")
            {
                MessageBox.Show("Attention, un des champs est vide!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Decimal.TryParse(txbxPrixTypeIngredientForm.Text, out Decimal valPrix))
            {
                MessageBox.Show("Attention, le prix n'est pas une valeur correct", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                switch (cible)
                {
                    case "Ajouter":
                        RemplirObj();
                        _controller.CreateTypeingredient(_obj);
                        break;
                    case "Modifier":
                        RemplirObj();
                        _controller.UpdateTypeingredient(_obj);
                        break;
                    case "Supprimer":
                        _controller.DeleteTypeingredient(_obj.IdTypeIngredient);
                        break;
                    default:
                        break;
                }
                this.Close();
            }
        }

        /// <summary>
        /// Remplissage des champs
        /// </summary>
        private void RemplirChamps()
        {
            txbxNomTypeIngredientForm.Text = _obj.NomTypeIngredient;
            txbxPrixTypeIngredientForm.Text = _obj.PrixTypeIngredient.ToString();
        }

        /// <summary>
        /// Désactivation des champs, pour éviter les signaux contraires lors de la suppression
        /// </summary>
        private void DesactiverChamps()
        {
            txbxNomTypeIngredientForm.IsEnabled = false;
            txbxPrixTypeIngredientForm.IsEnabled = false;
        }

        /// <summary>
        /// Mise à jour de l'objet avant appel de la fonction voulue
        /// </summary>
        private void RemplirObj()
        {
            _obj.NomTypeIngredient = txbxNomTypeIngredientForm.Text;
            Decimal valPrix;
            Decimal.TryParse(txbxPrixTypeIngredientForm.Text, out valPrix);
            _obj.PrixTypeIngredient = Decimal.Round(valPrix, 2);
        }
    }
}
