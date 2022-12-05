using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Cases
    {

        public Joueurs Contenu { get; set; }
        public bool EstVide { get; set; }

        /// <summary>
        /// Assignation d'un joueur à une case
        /// </summary>
        /// <param name="contenu"></param>
        public Cases(Joueurs contenu)
        {
            Contenu = contenu;
            EstVide = false;
        }

        /// <summary>
        /// Constructeur vide de la classe
        /// </summary>
        public Cases()
        {
            EstVide = true;
        }

        /// <summary>
        /// Check si la case est vide. Si oui, y affecte le joueur. Sinon, retourne que l'action est impossible
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool estJouable(Joueurs j)
        {
            if (EstVide)
            {
                Contenu = j;
                EstVide = false;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
