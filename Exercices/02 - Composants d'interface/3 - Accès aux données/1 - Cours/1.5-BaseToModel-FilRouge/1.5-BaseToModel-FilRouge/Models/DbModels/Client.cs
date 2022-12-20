using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Client
    {
        public Client()
        {
            Commandes = new HashSet<Commande>();
        }

        public int IdUser { get; set; }
        public string RefClient { get; set; }
        public int CoefClient { get; set; }
        public int IdAdresse { get; set; }
        public int IdCategorieClient { get; set; }

        public virtual Adress IdAdresseNavigation { get; set; }
        public virtual Categoriesclient IdCategorieClientNavigation { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
