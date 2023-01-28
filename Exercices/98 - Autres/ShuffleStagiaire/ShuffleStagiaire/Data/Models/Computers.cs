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
        public bool Utilise { get; set; }
        /// <summary>
        /// Stagiaire assigné à l'ordinateur
        /// </summary>
        public Stagiaires Stagiaire { get; set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="position"></param>
        /// <param name="patrimoine"></param>
        /// <param name="iP"></param>
        public Computers(int position, int patrimoine, string iP, bool utilise)
        {
            Position = position;
            Patrimoine = patrimoine;
            IP = iP;
            Utilise = utilise;
            Stagiaire = new Stagiaires();
        }

        public Computers()
        {
            Position = 0;
            Patrimoine = 999;
            IP = "10.xxx.xxx.xxx";
            Utilise = false;
            Stagiaire = new Stagiaires();
        }
        public Computers(int position)
        {
            Position = position;
            Patrimoine = 999;
            IP = "10.xxx.xxx.xxx";
            Utilise = false;
            Stagiaire = new Stagiaires();
        }
        public string PositionImage
        {
            get
            {
                return "/ShuffleStagiaire;component/IMG/Ordi" + Position+".png";
            }
        }
    }
}


