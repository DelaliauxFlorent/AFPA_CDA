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
            ListingCategories = new List<Categories>();
            ListingCategories.AddRange(CreerListeFileJSON());
            w.dtgdGrille.ItemsSource = ListingCategories;
        }

        public static List<Categories> CreerListeFileJSON()
        {
            String json = FichierJson.LireJSON(PathListCateg);
            List<Categories> listCategs = JsonConvert.DeserializeObject<List<Categories>>(json);
            return listCategs;
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
            return ListingCategories.Find(x => x.IdCategorie == iD);
        }
    }
}
