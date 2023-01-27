using Newtonsoft.Json;
using ShuffleStagiaire.Classes;
using ShuffleStagiaire.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleStagiaire.Data.Services
{
    class ComputersServices
    {
        public const string PathListComp = "../../ListeOrdinateurs.json";
        public static List<Computers> ListingComp { get; set; }

        public static void CreerListeFileJSON()
        {
            String json = FichiersJsons.LireJSON(PathListComp);
            ListingComp = JsonConvert.DeserializeObject<List<Computers>>(json);
        }

        public static void AjouterOrdi(Computers ordiAjout)
        {
            ListingComp.Add(ordiAjout);
            string json = JsonConvert.SerializeObject(ListingComp);
            FichiersJsons.UpdateListeFileJSON(json, PathListComp);
        }
        public static void ModifierOrdi(Computers ordi)
        {
            string json = JsonConvert.SerializeObject(ListingComp);
            FichiersJsons.UpdateListeFileJSON(json, PathListComp);
        }

        public static void SupprimerOrdi(Computers ordi)
        {
            ListingComp.Remove(ordi);
            string json = JsonConvert.SerializeObject(ListingComp);
            FichiersJsons.UpdateListeFileJSON(json, PathListComp);
        }

        public static Computers GetOrdiByStag(Stagiaires stag)
        {
            if (ListingComp.Exists(x => x.Stagiaire.IdStagiaire == stag.IdStagiaire))
            {
                return ListingComp.FirstOrDefault(x => x.Stagiaire.IdStagiaire == stag.IdStagiaire);
            }
            return new Computers();
        }
    }
}
