using ShuffleStagiaire.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleStagiaire.Data.Models
{
    public class Salles
    {
        public static int NbrePcs { get; set; }

        public Salles(int nbrePcs)
        {
            NbrePcs = nbrePcs;
            StagiairesServices.CreerListeFileJSON();
            ComputersServices.CreerListeFileJSON();            
        }

        public void PositionerPC(int position, Computers ordi)
        {
            ComputersServices.ListingComp.Insert(position, ordi);
        }
    }
}
