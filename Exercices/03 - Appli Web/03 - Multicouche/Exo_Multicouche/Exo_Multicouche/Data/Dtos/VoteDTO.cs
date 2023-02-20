using System;
using System.Collections.Generic;

#nullable disable

namespace Exo_Multicouche.Data.Dtos
{
    public class VoteDTO
    {
        public int IdVote { get; set; }
        public string ChoixVote { get; set; }
        public int IdCodeValide { get; set; }
    }
}
