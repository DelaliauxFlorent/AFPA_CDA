using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table Comptes
    /// </summary>
    public partial class Compte
    {
        /// <summary>
        /// Constructeur (pour les listes)
        /// </summary>
        public Compte()
        {
            Adresses = new HashSet<Adress>();
            Commandes = new HashSet<Commande>();
        }

        public int IdCompte { get; set; }
        public string Identifiant { get; set; }
        public string Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? NiveauFidelite { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
