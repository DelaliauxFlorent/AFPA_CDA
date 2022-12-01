using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Grilles
    {
        public Grilles(int nbreLignes, int nbreColonnes)
        {
            NbreLignes = nbreLignes;
            NbreColonnes = nbreColonnes;
            Tableau = new Cases[nbreColonnes, nbreLignes];
            for (int i = 0; i < nbreColonnes; i++)
            {
                for (int j = 0; j < nbreLignes; j++)
                {
                    Tableau[i, j] = new Cases();
                }
            }
        }

        public int NbreLignes { get; set; }
        public int NbreColonnes { get; set; }
        public Cases [,] Tableau { get;}


    }
}
