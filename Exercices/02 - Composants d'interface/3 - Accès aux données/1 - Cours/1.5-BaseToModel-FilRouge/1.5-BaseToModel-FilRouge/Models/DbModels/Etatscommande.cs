using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Etatscommande
    {
        public Etatscommande()
        {
            Histoetatcoms = new HashSet<Histoetatcom>();
        }

        public int IdEtatCommande { get; set; }
        public string LibelleEtatCommande { get; set; }

        public virtual ICollection<Histoetatcom> Histoetatcoms { get; set; }
    }
}
