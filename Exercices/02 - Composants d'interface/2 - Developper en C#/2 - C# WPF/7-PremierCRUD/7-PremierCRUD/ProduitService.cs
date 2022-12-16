using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    class ProduitService
    {
        public static List<Produits> CreerListeFileJSON(String fichier)
        {
            String json = FichierJSON.LireJSON(fichier);
            List<Produits> listProduits = JsonConvert.DeserializeObject<List<Produits>>(json);
            return listProduits;
        }
    }
}
