using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table Roles
    /// </summary>
    public partial class Role
    {
        /// <summary>
        /// Constructeur (pour la liste)
        /// </summary>
        public Role()
        {
            Comptes = new HashSet<Compte>();
        }

        public int IdRole { get; set; }
        public string NomRole { get; set; }
        public int? NiveauAcreditation { get; set; }

        public virtual ICollection<Compte> Comptes { get; set; }
    }
}
