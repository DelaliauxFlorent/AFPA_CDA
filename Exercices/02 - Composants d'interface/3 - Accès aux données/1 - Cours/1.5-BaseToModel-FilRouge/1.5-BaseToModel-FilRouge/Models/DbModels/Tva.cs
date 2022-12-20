using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Tva
    {
        public Tva()
        {
            Applicationstvas = new HashSet<Applicationstva>();
        }

        public int IdTva { get; set; }
        public int TauxTva { get; set; }

        public virtual ICollection<Applicationstva> Applicationstvas { get; set; }
    }
}
