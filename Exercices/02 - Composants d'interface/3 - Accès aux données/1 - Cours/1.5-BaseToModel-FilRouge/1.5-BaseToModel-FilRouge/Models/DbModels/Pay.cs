using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Pay
    {
        public Pay()
        {
            Villes = new HashSet<Ville>();
        }

        public int IdPays { get; set; }
        public string NomPays { get; set; }

        public virtual ICollection<Ville> Villes { get; set; }
    }
}
