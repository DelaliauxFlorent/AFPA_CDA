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
    public partial class DetailsProduit : Window
    {
        GestionProduits fenetreParente;
        public int IndexListe { get; set; }
        public String ModeOuverture { get; set; }
        public Produits ProduitPasse { get; set; }

        /// <summary>
        /// Constructeur de la fenêtre de détails
        /// </summary>
        /// <param name="w">La fenêtre "Mère"</param>
        /// <param name="mode">Le mode d'ouverture, Ajouter/Modifier/Supprimer</param>
        /// <param name="prod">Le produit concerné</param>
        public DetailsProduit(GestionProduits w, String mode, Produits prod = null)
        {
            InitializeComponent();
            fenetreParente = w;
            ModeOuverture = mode;
            ProduitPasse = prod;
            RemplirChamps();
        }

        /// <summary>
        /// Rempli les champs de la fenêtre en fonction du mode
        /// </summary>
        private void RemplirChamps()
        {
            // Change le texte du bouton de validation en fonction du mode
            btnValid.Content = ModeOuverture;
            switch (ModeOuverture)
            {
                case "Visualiser":
                    btnValid.Visibility = Visibility.Hidden;
                    this.Title = "Visualiser un produit";
                    btnAnnul.Content = "OK";
                    valChamp1.Content = ProduitPasse.IdProduit;
                    valChamp2.Text = ProduitPasse.LibelleProduit;
                    valChamp3.Text = ProduitPasse.NumeroProduit;
                    valChamp4.Text = ProduitPasse.Quantite.ToString();
                    DisableFields();
                    break;
                case "Ajouter":
                    // Si on a demandé à ajouter un produit:
                    // la seule valeur entrée par le logiciel et l'ID
                    // Par défaut, le nouvel ID suit l'ID du dernier élément de la liste
                    this.Title = "Ajouter un produit";
                    valChamp1.Content = ProduitService.ListingProduits[ProduitService.ListingProduits.Count - 1].IdProduit + 1;
                    break;
                case "Modifier":
                    // Si on a demandé à modifier un produit:
                    // on rempli les champs avec les valeurs du produit en question
                    this.Title = "Modifier un produit";
                    IndexListe = ProduitService.ListingProduits.IndexOf(ProduitPasse);
                    valChamp1.Content = ProduitPasse.IdProduit;
                    valChamp2.Text = ProduitPasse.LibelleProduit;
                    valChamp3.Text = ProduitPasse.NumeroProduit;
                    valChamp4.Text = ProduitPasse.Quantite.ToString();
                    break;
                case "Supprimer":
                    // Si on a demandé à supprimer un produit:
                    // on rempli les champs avec les valeurs du produit en question (pour confirmation)
                    // Mais on les désactives pour éviter les méprises
                    this.Title = "Supprimer un produit";
                    IndexListe = ProduitService.ListingProduits.IndexOf(ProduitPasse);
                    valChamp1.Content = ProduitPasse.IdProduit;
                    valChamp2.Text = ProduitPasse.LibelleProduit;
                    valChamp3.Text = ProduitPasse.NumeroProduit;
                    valChamp4.Text = ProduitPasse.Quantite.ToString();
                    DisableFields();
                    break;
                default:
                    break;
            }
        }

        private void DisableFields()
        {
            valChamp2.IsEnabled = false;
            valChamp3.IsEnabled = false;
            valChamp4.IsEnabled = false;
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
        /// Gère le clique sur le bouton de validation en fonction du mode d'ouverture de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            int idCateg = 1;
            // On vérifie qu'aucun des champs n'est vide
            if (valChamp2.Text != "" && valChamp3.Text != "" && valChamp4.Text != "")
            {
                // On vérifie que la quantité est un entier
                if (int.TryParse(valChamp4.Text, out int qte))
                {
                    // Et on peut dire à la classe ProduitService d'effectuer la fonction correspondante
                    switch (ModeOuverture)
                    {
                        case "Ajouter":
                            // On crée un nouveau produit avec les valeurs des différents champs
                            Produits newProd = new Produits((Int32)valChamp1.Content, valChamp2.Text, valChamp3.Text, qte, idCateg);
                            // On demande à ProduitService de l'ajouter au fichier
                            ProduitService.AjouterProduit(newProd);
                            break;
                        case "Modifier":
                            // On demande à ProduitService de modifier le fichier avec les valeurs des champs
                            ProduitService.ModifierProduit(ProduitPasse, valChamp2.Text, valChamp3.Text, qte, idCateg);
                            break;
                        case "Supprimer":
                            // On demande une dernière confirmation de la suppression
                            if (MessageBox.Show("Êtes-vous certain de vouloir supprimer cette entrée?", "Confirmer la suppression:", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel)==MessageBoxResult.OK)
                            {
                                // Si OK, on demande à ProduitService de supprimer ce produit du fichier
                                ProduitService.SupprimerProduit(ProduitPasse);
                            }
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
