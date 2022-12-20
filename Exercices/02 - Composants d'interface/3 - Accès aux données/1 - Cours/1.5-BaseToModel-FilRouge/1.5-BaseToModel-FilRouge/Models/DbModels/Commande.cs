using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Commande
    {
        public Commande()
        {
            Histoetatcoms = new HashSet<Histoetatcom>();
            Lignescommandes = new HashSet<Lignescommande>();
            Livraisons = new HashSet<Livraison>();
            Paiements = new HashSet<Paiement>();
        }

        public int IdCommande { get; set; }
        public string NumeroCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public int IdUser { get; set; }

        public virtual Client IdUserNavigation { get; set; }
        public virtual ICollection<Histoetatcom> Histoetatcoms { get; set; }
        public virtual ICollection<Lignescommande> Lignescommandes { get; set; }
        public virtual ICollection<Livraison> Livraisons { get; set; }
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
