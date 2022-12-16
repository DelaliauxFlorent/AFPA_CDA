using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    static class FichierJson
    {
        /// <summary>
        /// Récupérer une liste de produits à partir d'un JSON
        /// </summary>
        /// <param name="fichier">Adresse du fichier à lire</param>
        /// <returns>Liste sous forme de String</returns>
        public static String LireJSON(String fichier)
        {
            using (StreamReader r = new StreamReader(fichier))
            {
                String json = r.ReadToEnd();
                return json;
            }
        }

        /// <summary>
        /// Mets à jour un fichier avec la liste des produits
        /// </summary>
        /// <param name="fichier">Adresse du fichier à mettre à jour</param>
        public static void UpdateListeFileJSON(String fichier)
        {
            using (StreamWriter ecrire = new StreamWriter(fichier, false))
            {
                string json = JsonConvert.SerializeObject(ProduitService.ListingProduits);
                ecrire.Write(json);
            }
        }
    }
}
