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
        public bool EstVide { get; }

        public Cases(Joueurs contenu)
        {
            Contenu = contenu;
            EstVide = false;
        }
        public Cases()
        {
            EstVide = true;
        }

        public bool estJouable(Joueurs j)
        {
            if (EstVide)
            {
                Contenu = j;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
