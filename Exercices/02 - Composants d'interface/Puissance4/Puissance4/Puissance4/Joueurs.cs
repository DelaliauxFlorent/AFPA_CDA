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
        public String Couleur { get; set; }
        public char Signe { get; set; }
        public String Nom { get; set; }
        public static List<String> ListeCouleurs { get; }
        public static List<String> ListeSignes { get; }

        /// <summary>
        /// Constructeur de Classe
        /// </summary>
        /// <param name="number">Le numéro du joueur</param>
        /// <param name="color">La couleur choisie par le joueur</param>
        /// <param name="sign">Le signe choisi par le joueur</param>
        /// <param name="name">Le nom du joueur</param>
        public Joueurs(int number, String color, char sign, String name)
        {
            Num = number;
            Couleur = color;
            Signe = sign;
            Nom = name;
            //if(!(ListeCouleurs?.Any() ?? false)){
            //    ListeCouleurs.Add(color);
            //}
            //if (!(ListeSignes?.Any() ?? false))
            //{
            //    ListeSignes.Add(color);
            //}
        }

        public void afficherJoueur()
        {
            Console.WriteLine("\nJoueur:\n"+Num+"\t"+Nom+"\t"+Couleur+"\t"+Signe);
        }

        //public static bool couleurExiste(String color)
        //{
        //    return ListeCouleurs.Contains(color);
        //}
        //public static bool signeExiste(String sign)
        //{
        //    return ListeSignes.Contains(sign);
        //}
    }
}
