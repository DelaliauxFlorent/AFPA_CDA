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
    }
}
