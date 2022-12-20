using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Ville
    {
        public Ville()
        {
            Adresses = new HashSet<Adress>();
        }

        public int IdVille { get; set; }
        public string LibelleVille { get; set; }
        public string CodePostal { get; set; }
        public int IdPays { get; set; }

        public virtual Pay IdPaysNavigation { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }
    }
}
