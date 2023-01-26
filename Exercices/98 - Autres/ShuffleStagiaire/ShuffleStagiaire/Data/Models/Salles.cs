using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleStagiaire.Data.Models
{
    public class Salles
    {
        public int NbrePcs { get; set; }

        private static List<Computers> Liste;

        public Salles(int nbrePcs)
        {
            NbrePcs = nbrePcs;
            List<Computers> Liste = new List<Computers>();
            for (int i = 0; i < NbrePcs; i++)
            {
                Liste.Add(new Computers());
            }
        }

        public void PositionerPC(int position, Computers ordi)
        {
            Liste.Insert(position, ordi);
        }
    }
}
