using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table Statuts
    /// </summary>
    public partial class Statut
    {
        /// <summary>
        /// Constructeur (pour la liste)
        /// </summary>
        public Statut()
        {
            Commandes = new HashSet<Commande>();
        }

        public int IdStatut { get; set; }
        public string NomStatut { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
