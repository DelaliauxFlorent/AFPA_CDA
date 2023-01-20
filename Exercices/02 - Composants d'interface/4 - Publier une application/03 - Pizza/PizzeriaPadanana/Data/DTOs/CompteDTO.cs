using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.DTOs
{
    /// <summary>
    /// Classe des compteDTO
    /// </summary>
    public class CompteDTO
    {
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

    /// <summary>
    /// DTO Simple n'ayant que le nom, prénom, niveau de fidélité
    /// </summary>
    public class CompteDTO_Simple
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? NiveauFidelite { get; set; }
    }

    /// <summary>
    /// DTO de connexion
    /// </summary>
    public class CompteDTO_Connexion
    {
        public string Identifiant { get; set; }
        public string Mdp { get; set; }
    }

    /// <summary>
    /// DTO pour la création de compte
    /// </summary>
    public class CompteDTO_Creation
    {
        public string Identifiant { get; set; }
        public string Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Adresse { set; get; }
        public string ComplementAdresse { set; get; }
        public string CdPost { set; get; }
        public string Ville { set; get; }
    }
}
