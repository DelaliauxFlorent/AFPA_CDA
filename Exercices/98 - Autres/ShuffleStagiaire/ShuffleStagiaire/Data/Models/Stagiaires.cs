using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleStagiaire.Data.Models
{
    /// <summary>
    /// Classe des stagiaires
    /// </summary>
    public class Stagiaires
    {
        /// <summary>
        /// Id du stagiaire
        /// </summary>
        public int IdStagiaire { get; set; }
        /// <summary>
        /// Identifiant du stagiaire (59011-14-XX)
        /// </summary>
        public string Identifiant { get; set; }
        /// <summary>
        /// Nom du stagiaire
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="idStagiaire"></param>
        /// <param name="identifiant"></param>
        /// <param name="nom"></param>
        public Stagiaires(int idStagiaire, string identifiant, string nom)
        {
            IdStagiaire = idStagiaire;
            Identifiant = identifiant;
            Nom = nom;
        }

        /// <summary>
        /// Constructeur vide
        /// </summary>
        public Stagiaires()
        {
            IdStagiaire = 0;
            Identifiant = "";
            Nom = "";
        }
    }
}
