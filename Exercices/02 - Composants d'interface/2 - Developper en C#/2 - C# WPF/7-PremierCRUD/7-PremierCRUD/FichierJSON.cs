using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    class FichierJSON
    {
        public static String LireJSON(String fichier)
        {
            using (StreamReader r = new StreamReader(fichier))
            {
                String json = r.ReadToEnd();
                return json;
            }
        }

        /// <summary>
        /// Mise à jour du fichier JSON
        /// </summary>
        public static void UpdateListeFileJSON(String fichier)
        {
            using (StreamWriter ecrire = new StreamWriter(fichier, false))
            {
                string json = JsonConvert.SerializeObject(ProduitService.listingProduits);
                ecrire.Write(json);
            }
        }
    }
}
