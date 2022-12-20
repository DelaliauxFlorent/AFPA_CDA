using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Fournisseur
    {
        public Fournisseur()
        {
            Approvisions = new HashSet<Approvision>();
        }

        public int IdFournisseur { get; set; }
        public string NomFournisseur { get; set; }

        public virtual ICollection<Approvision> Approvisions { get; set; }
    }
}
