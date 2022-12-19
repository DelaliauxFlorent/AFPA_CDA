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
    /// Interaction logic for DetailsCategorie.xaml
    /// </summary>
    public partial class DetailsCategorie : Window
    {
        GestionCategories fenetreParente;
        public int IndexListe { get; set; }
        public String ModeOuverture { get; set; }
        public Categories CategoriePassee { get; set; }

        public DetailsCategorie(GestionCategories w, String mode, Categories categ = null)
        {
            InitializeComponent();
            fenetreParente = w;
            ModeOuverture = mode;
            CategoriePassee = categ;
            RemplirChamps();
        }

        private void RemplirChamps()
        {
            // Change le texte du bouton de validation en fonction du mode
            btnValid.Content = ModeOuverture;
            switch (ModeOuverture)
            {
                case "Visualiser":
                    btnValid.Visibility = Visibility.Hidden;
                    this.Title = "Visualiser une catégorie";
                    btnAnnul.Content = "OK";
                    valChamp1.Content = CategoriePassee.IdCategorie;
                    valChamp2.Text = CategoriePassee.LibelleCategorie;
                    DisableFields();
                    break;
                case "Ajouter":
                    // Si on a demandé à ajouter une catégorie:
                    // la seule valeur entrée par le logiciel et l'ID
                    // Par défaut, le nouvel ID suit l'ID du dernier élément de la liste
                    this.Title = "Ajouter une catégorie";
                    valChamp1.Content = CategorieService.ListingCategories[CategorieService.ListingCategories.Count - 1].IdCategorie + 1;
                    break;
                case "Modifier":
                    // Si on a demandé à modifier une catégorie:
                    // on rempli les champs avec les valeurs de la catégorie en question
                    this.Title = "Modifier une catégorie";
                    IndexListe = CategorieService.ListingCategories.IndexOf(CategoriePassee);
                    valChamp1.Content = CategoriePassee.IdCategorie;
                    valChamp2.Text = CategoriePassee.LibelleCategorie;
                    break;
                case "Supprimer":
                    // Si on a demandé à supprimer une catégorie:
                    // on rempli les champs avec les valeurs de la catégorie en question (pour confirmation)
                    // Mais on les désactives pour éviter les méprises
                    this.Title = "Supprimer une catégorie";
                    IndexListe = CategorieService.ListingCategories.IndexOf(CategoriePassee);
                    valChamp1.Content = CategoriePassee.IdCategorie;
                    valChamp2.Text = CategoriePassee.LibelleCategorie;
                    DisableFields();
                    break;
                default:
                    break;
            }
        }

        private void DisableFields()
        {
            valChamp2.IsEnabled = false;
        }

        private void btnAnnul_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            // On vérifie qu'aucun des champs n'est vide
            //if (valChamp2.Text != "" && valChamp3.Text != "" && valChamp4.Text != "")
            //{
            //    // On vérifie que la quantité est un entier
            //    if (int.TryParse(valChamp4.Text, out int qte))
            //    {
            //        // Et on peut dire à la classe ProduitService d'effectuer la fonction correspondante
            //        switch (ModeOuverture)
            //        {
            //            case "Ajouter":
            //                // On crée un nouveau produit avec les valeurs des différents champs
            //                Produits newProd = new Produits((Int32)valChamp1.Content, valChamp2.Text, valChamp3.Text, qte);
            //                // On demande à ProduitService de l'ajouter au fichier
            //                ProduitService.AjouterProduit(newProd);
            //                break;
            //            case "Modifier":
            //                // On demande à ProduitService de modifier le fichier avec les valeurs des champs
            //                ProduitService.ModifierProduit(ProduitPasse, valChamp2.Text, valChamp3.Text, qte);
            //                break;
            //            case "Supprimer":
            //                // On demande une dernière confirmation de la suppression
            //                if (MessageBox.Show("Êtes-vous certain de vouloir supprimer cette entrée?", "Confirmer la suppression:", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            //                {
            //                    // Si OK, on demande à ProduitService de supprimer ce produit du fichier
            //                    ProduitService.SupprimerProduit(ProduitPasse);
            //                }
            //                break;
            //            default:
            //                break;
            //        }
            //        this.Close();
            //    }
            //    else
            //    {
            //        // Sinon, on informe l'utilisateur du problème et c'est tous
            //        MessageBox.Show("Le champ \"Quantité\" doit être en entier!", "Erreur de format", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else
            //{
            //    // Sinon, on informe l'utilisateur du problème et c'est tous
            //    MessageBox.Show("Un de vos champs est vide!", "Information manquante", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
