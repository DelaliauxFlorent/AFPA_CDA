using System;
using System.Collections.Generic;

#nullable disable

namespace _3_CreerAPI.Models
{
    public partial class Personne
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
    }
}
