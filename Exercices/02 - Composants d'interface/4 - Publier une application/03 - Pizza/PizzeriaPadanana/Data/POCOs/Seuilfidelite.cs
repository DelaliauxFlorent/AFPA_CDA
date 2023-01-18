using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Seuilfidelite
    {
        public Seuilfidelite()
        {
            Commandes = new HashSet<Commande>();
        }

        public int IdSeuilFidelite { get; set; }
        public int MaxSeuil { get; set; }
        public int MontantFidelite { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
