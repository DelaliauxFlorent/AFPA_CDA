using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Commande
    {
        public Commande()
        {
            Lignescommandes = new HashSet<Lignescommande>();
        }

        public int IdCommande { get; set; }
        public string NumCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public bool PayementCommande { get; set; }
        public int? IdSeuilFidelite { get; set; }
        public int? IdCompte { get; set; }
        public int? IdStatut { get; set; }

        public virtual Compte IdCompteNavigation { get; set; }
        public virtual Seuilfidelite IdSeuilFideliteNavigation { get; set; }
        public virtual Statut IdStatutNavigation { get; set; }
        public virtual ICollection<Lignescommande> Lignescommandes { get; set; }
    }
}
