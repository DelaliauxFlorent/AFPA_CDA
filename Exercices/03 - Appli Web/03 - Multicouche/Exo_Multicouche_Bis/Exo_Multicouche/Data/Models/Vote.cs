using System;
using System.Collections.Generic;

#nullable disable

namespace Exo_Multicouche.Data.Models
{
    public partial class Vote
    {
        public int IdVote { get; set; }
        public string ChoixVote { get; set; }
        public int IdCodeValide { get; set; }

        public virtual CodesValide CodesValide { get; set; }
    }
}
