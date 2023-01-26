using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleStagiaire.Classes
{
    static class FichiersJsons
    {
        /// <summary>
        /// Récupérer une liste de produits à partir d'un JSON
        /// </summary>
        /// <param name="fichier">Adresse du fichier à lire</param>
        /// <returns>Liste sous forme de String</returns>
        public static String LireJSON(String path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                String json = r.ReadToEnd();
                return json;
            }
        }

        /// <summary>
        /// Mets à jour un fichier avec la liste des produits
        /// </summary>
        /// <param name="fichier">Adresse du fichier à mettre à jour</param>
        public static void UpdateListeFileJSON(String json, String path)
        {
            using (StreamWriter ecrire = new StreamWriter(path, false))
            {
                ecrire.Write(json);
            }
        }
    }
}
