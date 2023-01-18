using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    class CategorieService
    {
        public static List<Categories> ListingCategories { get; set; }
        public const string PathListCateg = "../../ListeCategories.json";

        public static void RemplirGrid(GestionCategories w)
        {
            CreerListeFileJSON();
            w.dtgdGrille.ItemsSource = ListingCategories;
        }

        public static void CreerListeFileJSON()
        {
            String json = FichierJson.LireJSON(PathListCateg);
            ListingCategories = JsonConvert.DeserializeObject<List<Categories>>(json);
        }

        public static void ModifierCategorie(Categories categModif, String lbl)
        {
            categModif.LibelleCategorie = lbl;
            string json = JsonConvert.SerializeObject(ListingCategories);
            FichierJson.UpdateListeFileJSON(json, PathListCateg);
        }

        public static void AjouterCategorie(Categories categAjout)
        {
            ListingCategories.Add(categAjout);
            string json = JsonConvert.SerializeObject(ListingCategories);
            FichierJson.UpdateListeFileJSON(json, PathListCateg);
        }

        public static void SupprimerCategorie(Categories categSuppr)
        {
            ListingCategories.Remove(categSuppr);
            string json = JsonConvert.SerializeObject(ListingCategories);
            FichierJson.UpdateListeFileJSON(json, PathListCateg);
        }

        public static Categories FindById(int iD)
        {
            if (ListingCategories.Find(x => x.IdCategorie == iD) != null)
            {
                return ListingCategories.Find(x => x.IdCategorie == iD);
            }
            else
            {
                return new Categories();
            }
        }
    }
}
