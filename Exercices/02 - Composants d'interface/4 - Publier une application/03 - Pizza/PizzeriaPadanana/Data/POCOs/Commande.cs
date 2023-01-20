using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table Commandes
    /// </summary>
    public partial class Commande
    {
        /// <summary>
        /// Constructeur (pour la liste)
        /// </summary>
        public Commande()
        {
            Lignescommandes = new HashSet<Lignescommande>();
        }

        /// <summary>
        /// ID de la commande
        /// </summary>
        public int IdCommande { get; set; }
        /// <summary>
        /// Numéro de la commande
        /// </summary>
        public string NumCommande { get; set; }
        /// <summary>
        /// Date de la commande
        /// </summary>
        public DateTime DateCommande { get; set; }
        /// <summary>
        /// Si la commande a été payée
        /// </summary>
        public bool PayementCommande { get; set; }
        /// <summary>
        /// Seuil de Fidélité
        /// </summary>
        public int? IdSeuilFidelite { get; set; }
        /// <summary>
        /// ID du compte ayant passé la commande
        /// </summary>
        public int? IdCompte { get; set; }
        /// <summary>
        /// ID du statut de la commande
        /// </summary>
        public int? IdStatut { get; set; }

        /// <summary>
        /// Infos du compte associé à la commande
        /// </summary>
        public virtual Compte IdCompteNavigation { get; set; }
        /// <summary>
        /// Infos du seuil de fidélité de la commande
        /// </summary>
        public virtual Seuilfidelite IdSeuilFideliteNavigation { get; set; }
        /// <summary>
        /// Infos sur le statut de la commande
        /// </summary>
        public virtual Statut IdStatutNavigation { get; set; }
        /// <summary>
        /// Liste des lignes de commandes associées à la commande actuelle
        /// </summary>
        public virtual ICollection<Lignescommande> Lignescommandes { get; set; }
    }
}
