using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Joueurs
    {
        /// <summary>
        /// Attributs
        /// </summary>

        public int Num { get; set; }
        private string couleur;
        private string signe;
        private string nom;
        private static string[] listeCouleurs;
        private static string[] listeSignes;
        public int CmptrJoueur { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="number">Le numéro du joueur</param>
        /// <param name="color">La couleur choisie par le joueur</param>
        /// <param name="sign">Le signe choisi par le joueur</param>
        /// <param name="name">Le nom du joueur</param>
        public Joueurs(int number, string color, string sign, string name)
        {
            this.num = number;
            this.couleur = color;
            this.signe = sign;
            this.nom = name;
            Array.Resize(ref listeCouleurs, listeCouleurs.Length + 1);
            
        }


    }
}
