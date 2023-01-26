using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleStagiaire.Data.Models
{
    /// <summary>
    /// Classe des ordinateurs
    /// </summary>
    public class Computers
    {
        /// <summary>
        /// Position de l'ordinateur dans la salle
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Numéro de l'ordinateur
        /// </summary>
        public int Patrimoine { get; set; }
        /// <summary>
        /// IP de l'ordinateur
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// Stagiaire assigné à l'ordinateur
        /// </summary>
        public Stagiaires Stagiaire { get; set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="position"></param>
        /// <param name="reference"></param>
        /// <param name="iP"></param>
        public Computers(int position, int patrimoine, string iP)
        {
            Position = position;
            Patrimoine = patrimoine;
            IP = iP;
            Stagiaire = new Stagiaires();
        }

        public Computers()
        {

        }
    }
}
