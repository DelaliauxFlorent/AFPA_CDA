using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Reglement
    {
        public Reglement()
        {
            Paiements = new HashSet<Paiement>();
        }

        public int IdReglement { get; set; }
        public string TypePaiement { get; set; }

        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
