using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Categoriesclient
    {
        public Categoriesclient()
        {
            Clients = new HashSet<Client>();
        }

        public int IdCategorieClient { get; set; }
        public string LibelleCategClient { get; set; }
        public string InfoReglement { get; set; }
        public int CoefCategClient { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
