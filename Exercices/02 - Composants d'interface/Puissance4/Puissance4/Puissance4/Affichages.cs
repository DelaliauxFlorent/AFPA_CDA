using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Affichages
    {
        public static int demandeNbreJoueurs()
        {
            Console.Write("Nombre de joueurs: ");
            int nbJoueur = Convert.ToInt32(Console.ReadLine());
            return nbJoueur;
        }

        public static Joueurs demandeInfoJoueur(int num)
        {
            Console.WriteLine("\nQuel est le nom du joueur " + num + "?");
            String nomJoueur = Console.ReadLine();
            Console.WriteLine("Quel couleur?");
            String couleurJoueur = Console.ReadLine();
            Console.WriteLine("Quel caractère?");
            char signJoueur = Console.ReadKey().KeyChar;
            Joueurs player = new Joueurs(num, couleurJoueur, signJoueur, nomJoueur);
            return player;
        }

        public static int demandeNbreAligne()
        {
            Console.WriteLine("Combien de jetons identiques doivent-ils être alignés pour remporter la partie?");
            int nbAligne = Convert.ToInt32(Console.ReadLine());
            return nbAligne;
        }

        public static int demandeNbreLignes()
        {
            Console.WriteLine("De combien de lignes est constituée la grille?");
            int nbreLigne = Convert.ToInt32(Console.ReadLine());
            return nbreLigne;
        }
        public static int demandeNbreColonnes()
        {
            Console.WriteLine("De combien de colonnes est constituée la grille?");
            int nbreColonne = Convert.ToInt32(Console.ReadLine());
            return nbreColonne;
        }

        public static void afficheGrille(Grilles grilleJeu)
        {
            for (int i = grilleJeu.NbreLignes - 1; i >= 0; i--)
            {
                for (int j = grilleJeu.NbreColonnes - 1; j >= 0; j--)
                {
                    Console.Write(" ");
                    if (grilleJeu.Tableau[j, i].EstVide)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(grilleJeu.Tableau[j, i].Contenu.Signe);
                    }
                    Console.Write(" |");
                }
                Console.Write("\n");
            }
        }
        public static void afficheInviteJoueur(Joueurs j)
        {
            Console.WriteLine("C'est à " + j.Nom + " de jouer!");
        }

        public static int demanderColonne(Grilles grilleJeu)
        {
            int choixColonne;
            bool erreurCol = false;
            do
            {
                Console.WriteLine("Dans quel colonne mettre le jeton?");
                choixColonne = Convert.ToInt32(Console.ReadLine());
                if (0 > choixColonne || choixColonne > grilleJeu.NbreColonnes)
                {
                    erreurCol = true;
                    Console.WriteLine("Erreur! Cette colonne n'existe pas.");
                }
                else if (grilleJeu.colonnePleine(choixColonne))
                {
                    erreurCol = true;
                    Console.WriteLine("Erreur! Cette colonne est déjà pleine.");
                }

            } while (erreurCol);
            return choixColonne;
        }
        public void afficheResultat(Joueurs j, bool gagne)
        {

        }
    }
}
