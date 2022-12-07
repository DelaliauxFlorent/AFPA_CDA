using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaires
{
    class Entreprises
    {

        public Entreprises(string nomEntreprise, List<Commerciaux> listeCommerciaux, List<Techniciens> listeTechniciens)
        {
            NomEntreprise = nomEntreprise;
            ListeCommerciaux = listeCommerciaux;
            ListeTechniciens = listeTechniciens;
        }

        public String NomEntreprise { get; set; }
        public List<Commerciaux> ListeCommerciaux { get; set; }
        public List<Techniciens> ListeTechniciens { get; set; }

        public Double MasseSalarial()
        {
            Double masseSalariale = 0;
            List<Salaries> liste = new List<Salaries>();
            liste.AddRange(ListeCommerciaux);
            liste.AddRange(ListeTechniciens);
            foreach (var salarie in liste)
            {
                masseSalariale += salarie.CalculSalaire();
            }
            return masseSalariale;
        }

        public void AfficherRepartSalaire()
        {
            Console.WriteLine("Répartition des salaires\n\n");
            Console.WriteLine(" COMMERCIAUX");
            foreach (var comm in ListeCommerciaux)
            {
                Console.WriteLine("\t" + comm);
            }
            Console.WriteLine("\n TECHNICIENS");
            foreach (var tech in ListeTechniciens)
            {
                Console.WriteLine("\t" + tech);
            }
            Console.WriteLine("\n soit un total de " + MasseSalarial());
        }
    }
}
