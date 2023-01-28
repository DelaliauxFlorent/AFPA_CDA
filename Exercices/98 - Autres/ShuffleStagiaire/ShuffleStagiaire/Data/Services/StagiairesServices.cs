using ShuffleStagiaire.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShuffleStagiaire.Tools;
using System.IO;

namespace ShuffleStagiaire.Data.Services
{
    class StagiairesServices
    {
        /// <summary>
        /// Path vers le fichier de sauvegarde des stagiaires
        /// </summary>
        public const string PathListStag = "./Data/ListeStagiaires.json";
        public static List<Stagiaires> ListingStagiaires { get; set; }
        public static int nbreStagiaire;

        public static void CreerListeFileJSON()
        {
            if (File.Exists(PathListStag))
            {
                String json = FichiersJsons.LireJSON(PathListStag);
                ListingStagiaires = JsonConvert.DeserializeObject<List<Stagiaires>>(json);
            }
            else
            {
                ListingStagiaires = new List<Stagiaires>();
            }
            nbreStagiaire = ListingStagiaires.Count();
        }

        public static void AjouterStagiaire(Stagiaires stagAjout)
        {
            ListingStagiaires.Add(stagAjout);
            nbreStagiaire++;
            string json = JsonConvert.SerializeObject(ListingStagiaires);
            FichiersJsons.UpdateListeFileJSON(json, PathListStag);
        }

        public static void ModifierStagiaire()
        {
            string json = JsonConvert.SerializeObject(ListingStagiaires);
            FichiersJsons.UpdateListeFileJSON(json, PathListStag);
        }

        public static void SupprimerStagiaire(Stagiaires stag)
        {
            ListingStagiaires.Remove(stag);
            nbreStagiaire--;
            string json = JsonConvert.SerializeObject(ListingStagiaires);
            FichiersJsons.UpdateListeFileJSON(json, PathListStag);
        }

        public static void ReInitStag()
        {
            ListingStagiaires.Clear();
            nbreStagiaire = 0;
            ModifierStagiaire();
        }
    }
}
