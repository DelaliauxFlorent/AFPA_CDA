using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    class Entreprises
    {
        public Entreprises(string nomEntreprise)
        {
            NomEntreprise = nomEntreprise;
        }

        public Entreprises(string nomEntreprise, List<Commerciaux> listeCommerciaux, List<Techniciens> listeTechniciens)
        {
            NomEntreprise = nomEntreprise;
            ListeCommerciaux = listeCommerciaux;
            ListeTechniciens = listeTechniciens;
        }

        public String NomEntreprise { get; set; }
        public List<Commerciaux> ListeCommerciaux { get; set; }
        public List<Techniciens> ListeTechniciens { get; set; }
        public Double MasseSalariale { get; set; }

        public void AjouterCommercial(Commerciaux com)
        {
            ListeCommerciaux.Add(com);
        }
        public void AjouterTechnicien(Techniciens tech)
        {
            ListeTechniciens.Add(tech);
        }

        public Double CalculMasseSalarial()
        {
            Double MasseSalariale = 0;
            //MasseSalariale += ListeCommerciaux.Sum();
            foreach (var Commercial in ListeCommerciaux)
            {
                MasseSalariale += Commercial.Salaire;
            }
        }

    }
}
