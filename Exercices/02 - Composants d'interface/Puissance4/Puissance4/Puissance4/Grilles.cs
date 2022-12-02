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

        public bool colonnePleine(int colonne)
        {
            return !(Tableau[colonne - 1, NbreLignes - 1].EstVide);
        }

        public bool estPleine()
        {
            for (int i = 0; i < NbreColonnes; i++)
            {
                for (int j = 0; j < NbreLignes; j++)
                {
                    if(Tableau[i, j].EstVide)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int premVide(int colonne)
        {
            int i = 0;
            do
            {
                if (Tableau[colonne, i].EstVide)
                {
                    return i;
                }
                i++;
            } while (i < NbreLignes);
            return -1;
        }

        public int estAligne(int colonne, int ligne, int dirCol, int dirLig)
        {
            int newCol = colonne + dirCol;
            int newLig = ligne + dirLig;
            if(0<=newCol && newCol < NbreColonnes && 0<= newLig && newLig < NbreLignes)
            {
                char signeActu = Tableau[colonne, ligne].Contenu.Signe;
                char signeDir = Tableau[newCol, newLig].Contenu.Signe;
                if (signeActu == signeDir)
                {
                    return 1 + estAligne(newCol, newLig, dirCol, dirLig);
                }
                else
                {
                    return 1;
                }
            }
            return 1;
        }

    }
}
