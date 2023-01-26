using ShuffleStagiaire.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShuffleStagiaire.Classes;

namespace ShuffleStagiaire.Data.Services
{
    class StagiairesServices
    {
        /// <summary>
        /// Path vers le fichier de sauvegarde des stagiaires
        /// </summary>
        public const string PathListStag = "../../ListeStagiaires.json";
        public static List<Stagiaires> ListingStagiaires { get; set; }

        public static void CreerListeFileJSON()
        {
            String json = FichiersJsons.LireJSON(PathListStag);
            ListingStagiaires = JsonConvert.DeserializeObject<List<Stagiaires>>(json);
        }

        public static void AjouterStagiaire(Stagiaires stagAjout)
        {
            ListingStagiaires.Add(stagAjout);
            string json = JsonConvert.SerializeObject(ListingStagiaires);
            FichiersJsons.UpdateListeFileJSON(json, PathListStag);
        }

        public static void ModifierStagiaire(Stagiaires stag)
        {
            string json = JsonConvert.SerializeObject(ListingStagiaires);
            FichiersJsons.UpdateListeFileJSON(json, PathListStag);
        }

        public static void SupprimerStagiaire(Stagiaires stag)
        {
            ListingStagiaires.Remove(stag);
            string json = JsonConvert.SerializeObject(ListingStagiaires);
            FichiersJsons.UpdateListeFileJSON(json, PathListStag);
        }
    }
}
