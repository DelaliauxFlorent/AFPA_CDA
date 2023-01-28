using Newtonsoft.Json;
using ShuffleStagiaire.Tools;
using ShuffleStagiaire.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleStagiaire.Data.Services
{
    class ComputersServices
    {
        public const string PathListComp = "./Data/ListeOrdinateurs.json";
        public static List<Computers> ListingComp { get; set; }

        public static void CreerListeFileJSON()
        {
            ListingComp = new List<Computers>();
            if (File.Exists(PathListComp))
            {
                String json = FichiersJsons.LireJSON(PathListComp);
                ListingComp = JsonConvert.DeserializeObject<List<Computers>>(json);
            }
            else
            {
                for (int i = 1; i <= Salles.NbrePcs; i++)
                {
                    ListingComp.Add(new Computers(i));
                }
            }
        }

        public static void AjouterOrdi(Computers ordiAjout)
        {
            ListingComp.Add(ordiAjout);
            string json = JsonConvert.SerializeObject(ListingComp);
            FichiersJsons.UpdateListeFileJSON(json, PathListComp);
        }
        public static void ModifierOrdi()
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
            if ((stag!=null)&&(ListingComp.Exists(x => x.Stagiaire.IdStagiaire == stag.IdStagiaire)))
            {
                return ListingComp.FirstOrDefault(x => x.Stagiaire.IdStagiaire == stag.IdStagiaire);
            }
            return new Computers();
        }

        public static void ResetSatgiairesComputers()
        {
            foreach (Computers ordi in ListingComp)
            {
                ordi.Stagiaire = new Stagiaires();
            }
            ModifierOrdi();
        }

        public static List<Computers> ListeOrdiInUse()
        {
            return ListingComp.FindAll(o => o.Utilise == true);
        }
    }
}
