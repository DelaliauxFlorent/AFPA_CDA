using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Statut
    {
        public Statut()
        {
            Commandes = new HashSet<Commande>();
        }

        public int IdStatut { get; set; }
        public string NomStatut { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
