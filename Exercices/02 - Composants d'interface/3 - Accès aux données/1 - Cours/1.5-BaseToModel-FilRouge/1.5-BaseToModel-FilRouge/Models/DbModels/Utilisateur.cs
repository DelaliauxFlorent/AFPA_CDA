using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Utilisateur
    {
        public int IdUser { get; set; }
        public string NomUser { get; set; }
        public string PrenomUser { get; set; }
        public string EmailUser { get; set; }
        public string MdpUser { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
    }
}
