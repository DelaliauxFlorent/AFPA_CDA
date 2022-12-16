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

namespace _7_PremierCRUD
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        MainWindow fenetreParente;
        int indexListe;
        String modeOuverture;

        public Details(MainWindow w, String mode, Produits prod = null)
        {
            InitializeComponent();
            fenetreParente = w;
            modeOuverture = mode;
            RemplirChamps(prod);
        }

        private void RemplirChamps(Produits p = null)
        {
            btnValid.Content = modeOuverture;
            switch (modeOuverture)
            {
                case "Ajouter":
                    indexListe = ProduitService.listingProduits.Count();
                    valChamp1.Content = ProduitService.listingProduits[indexListe - 1].IdProduit + 1;
                    break;
                case "Modifier":
                    indexListe = ProduitService.listingProduits.IndexOf(p);
                    valChamp1.Content = p.IdProduit;
                    valChamp2.Text = p.LibelleProduit;
                    valChamp3.Text = p.NumeroProduit;
                    valChamp4.Text = p.Quantite.ToString();
                    break;
                case "Supprimer":
                case "Afficher":
                    indexListe = ProduitService.listingProduits.IndexOf(p);
                    valChamp1.Content = p.IdProduit;
                    valChamp2.IsEnabled = false;
                    valChamp2.Text = p.LibelleProduit;
                    valChamp3.IsEnabled = false;
                    valChamp3.Text = p.NumeroProduit;
                    valChamp4.IsEnabled = false;
                    valChamp4.Text = p.Quantite.ToString();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Si on veut annuler, on ferme simplement la fenêtre sans rien faire d'autre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnul_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gestion de la tentative de modification d'une entrée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            if (valChamp2.Text != "" && valChamp3.Text != "" && valChamp4.Text != "")
            {
                //on change pas l'ID et le libelle peut être "n'importe quoi", mais pas vide
                // Mais la quantité doit être un entier
                if (int.TryParse(valChamp4.Text, out int qte))
                {
                    // Si c'est bien le cas, on peut dire à la fenêtre parente de réaliser les modifs voulues
                    String fichier = MainWindow.PathListProd;
                    Produits newProd = new Produits((Int32)valChamp1.Content, valChamp2.Text, valChamp3.Text, qte);
                    switch (modeOuverture)
                    {
                        case "Ajouter":
                            ProduitService.AjouterListe(newProd, fichier);
                            break;
                        case "Modifier":
                            ProduitService.ModifierListe(newProd, indexListe, fichier);
                            break;
                        default:
                            break;
                    }
                    this.Close();
                }
                else
                {
                    // Sinon, on informe l'utilisateur du problème et c'est tous
                    MessageBox.Show("Le champ \"Quantité\" doit être en entier!", "Erreur de format", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Sinon, on informe l'utilisateur du problème et c'est tous
                MessageBox.Show("Un de vos champs est vide!", "Information manquante", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
