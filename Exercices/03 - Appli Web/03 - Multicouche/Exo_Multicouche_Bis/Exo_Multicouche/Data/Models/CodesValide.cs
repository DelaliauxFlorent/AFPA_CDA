using System;
using System.Collections.Generic;

#nullable disable

namespace Exo_Multicouche.Data.Models
{
    public partial class CodesValide
    {
        public CodesValide()
        {
            Votes = new HashSet<Vote>();
        }

        public int IdCodeValide { get; set; }
        public string CodeValide { get; set; }
        public bool Utilise { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
