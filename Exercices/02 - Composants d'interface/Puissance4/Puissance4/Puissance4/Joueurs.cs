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
        public ConsoleColor Couleur { get; set; }
        public char Signe { get; set; }
        public String Nom { get; set; }
        public static readonly List<ConsoleColor> ListeCouleurs = new List<ConsoleColor>();
        public static readonly List<char> ListeSignes = new List<char>();

        /// <summary>
        /// Constructeur de Classe
        /// </summary>
        /// <param name="number">Le numéro du joueur</param>
        /// <param name="name">Le nom du joueur</param>
        /// <param name="color">La couleur choisie par le joueur</param>
        /// <param name="sign">Le signe choisi par le joueur</param>
        public Joueurs(int number, String name, ConsoleColor color, char sign)
        {
            Num = number;
            Nom = name;
            Couleur = color;
            Signe = sign;
            ListeCouleurs.Add(color);
            ListeSignes.Add(sign);
        }

        /// <summary>
        /// Afficher les infos d'un joueur (debug)
        /// </summary>
        public void afficherJoueur()
        {
            Console.Write("Joueur "+Num+":\n" + "\t" + Nom + "\t");
            Console.ForegroundColor = Couleur;
            Console.Write(Signe);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Check si la couleur a déjà été choisie
        /// </summary>
        /// <param name="colorC">Couleur à vérifier</param>
        /// <returns></returns>
        public static bool couleurExiste(ConsoleColor colorC)
        {
            return ListeCouleurs.Contains(colorC);
        }

        /// <summary>
        /// Check si le signe a déjà été choisi
        /// </summary>
        /// <param name="sign">Signe à vérifier</param>
        /// <returns></returns>
        public static bool signeExiste(char sign)
        {
            return ListeSignes.Contains(sign);
        }
    }
}
