using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Affichages
    {
        public static readonly String[] ListeCouleursT = {" 1 - Bleu Foncé", " 2 - Vert Foncé", " 3 - Cyan Foncé", " 4 - Rouge Foncé", " 5 - Magenta Foncé", " 6 - Jaune Foncé", " 7 - Gris", " 8 - Gris Foncé", " 9 - Bleu", "10 - Vert", "11 - Cyan", "12 - Rouge", "13 - Magenta", "14 - Jaune", "15 - Blanc"};

        public static readonly ConsoleColor[] consoleColors
            = (ConsoleColor[])ConsoleColor
                  .GetValues(typeof(ConsoleColor));

        /// <summary>
        /// Demande le nombre de joueurs participants
        /// </summary>
        /// <returns>int</returns>
        public static int demandeNbreJoueurs()
        {
            bool erreurDmdNbJ=false;
            int nbJoueur=2;
            do
            {
                Console.WriteLine("Nombre de joueurs: ");
                String nbJ = Console.ReadLine();
                if (nbJ != "")
                {
                    erreurDmdNbJ = !int.TryParse(nbJ, out nbJoueur);
                    if (erreurDmdNbJ)
                    {
                        Console.WriteLine("Erreur! Veuillez entrer un nombre.");
                    }
                }
                else
                {
                    erreurDmdNbJ = true;
                }
            } while (erreurDmdNbJ);
            
            return nbJoueur;
        }


        /// <summary>
        /// Demande les info d'un joueur spécifique
        /// </summary>
        /// <param name="num">Son ID</param>
        /// <returns>Un joueur avec un ID, un nom, une couleur et un signe</returns>
        public static Joueurs demandeInfoJoueur(int num)
        {
            bool erreurNom = false;
            bool erreurColor = false;
            bool erreurSigne = false;


            String nomJoueur;
            ConsoleColor couleurJoueur = ConsoleColor.Gray;
            char signJoueur = '#';
            String choixSign;

            //Demande du nom
            do
            {
                Console.WriteLine("\nQuel est le nom du joueur " + num + "?");
                nomJoueur = Console.ReadLine();
                if (nomJoueur == "")
                {
                    erreurNom = true;   // Erreur si champ vide
                    Console.WriteLine("Erreur! Le nom ne peut être vide.");
                }
                else
                {
                    erreurNom = false;
                }
            } while (erreurNom);   
            
            //Demande de la couleur
            do
            {
                //Affichage de la liste des couleurs possibles
                Console.WriteLine("Liste des couleurs possibles:");
                for (int i = 0; i < ListeCouleursT.Length; i++)
                {
                    Console.Write(ListeCouleursT[i]);
                    if (i % 3 == 2)
                    {
                        Console.Write("\n");
                    }
                    else
                    {
                        if (i != 3)
                        {
                            Console.Write("\t");
                        }
                        if(i==10 || i==13)
                        {
                            Console.Write("\t");
                        }
                        Console.Write("\t| ");
                    }                    
                }
                Console.WriteLine("\nQuel couleur utiliser (numéro)?");
                String choixCouleur = Console.ReadLine();
                if (int.TryParse(choixCouleur, out int ChoixColorNum))
                {
                    if (ChoixColorNum > 0 && ChoixColorNum < 16)
                    {
                        if (!Joueurs.couleurExiste(consoleColors[ChoixColorNum]))
                        {
                            erreurColor = false;
                            couleurJoueur = consoleColors[ChoixColorNum];
                        }
                        else
                        {
                            erreurColor = true;
                            Console.WriteLine("Erreur! Cette couleur a déjà été attribuée.");
                        }
                    }
                    else
                    {
                        erreurColor = true;
                        Console.WriteLine("Erreur! Ce numéro ne correspond à aucune couleur.");
                    }

                }
                else
                {
                    erreurColor = true;
                    Console.WriteLine("Erreur! Entrée invalide, veuillez donner le numéro correspondant à la couleur voulue.");
                }
            } while (erreurColor);

            // Demande du caractère
            do
            {
                Console.WriteLine("Quel caractère?");
                choixSign = Console.ReadLine();
                if (choixSign.Length==1)
                {
                    char.TryParse(choixSign, out signJoueur);
                    if (Joueurs.signeExiste(signJoueur))
                    {
                        erreurSigne = true;
                        Console.WriteLine("Erreur! Ce signe est déjà utilisé. Veuillez en choisir un autre.");
                    }
                    else
                    {
                        erreurSigne = false;
                    }
                }
                else
                {
                    erreurSigne = true;
                    Console.WriteLine("Erreur! Il vous faut un et un seul caractère.");
                }
                
            } while (erreurSigne);
            
            Joueurs player = new Joueurs(num-1, nomJoueur, couleurJoueur, signJoueur);
            return player;
        }

        /// <summary>
        /// Demande le nombre de jeton devant être alignés pour que le joueur gagne
        /// </summary>
        /// <returns>int</returns>
        public static int demandeNbreAligne(Grilles grilleJeu)
        {
            bool erreurDmdNbAli = false;
            String nbAlignT;
            int nbAligne;
            do
            {
                Console.WriteLine("Combien de jetons identiques doivent-ils être alignés pour remporter la partie?");
                nbAlignT = Console.ReadLine();
                erreurDmdNbAli = !int.TryParse(nbAlignT, out nbAligne);
                if (erreurDmdNbAli)
                {
                    Console.WriteLine("Erreur! Veuillez entrer un nombre.");
                }
                else
                {
                    if (nbAligne<3)
                    {
                        erreurDmdNbAli = true;
                        Console.WriteLine("Erreur! Cette valeur est trop petite.");
                    }else if(nbAligne>=Math.Max(grilleJeu.NbreColonnes, grilleJeu.NbreLignes))
                    {
                        erreurDmdNbAli = true;
                        Console.WriteLine("Erreur! Cette valeur est trop grande.");
                    }
                    else
                    {
                        erreurDmdNbAli = false;
                    }
                }
            } while (erreurDmdNbAli);            
            return nbAligne;
        }

        /// <summary>
        /// Demande le nombre de lignes de la grille
        /// </summary>
        /// <returns>int</returns>
        public static int demandeNbreLignes()
        {
            bool erreurDmdNbLig = false;
            String choixNbLigne;
            int nbreLigne;
            do
            {
                Console.WriteLine("De combien de lignes est constituée la grille? (Min=6)");
                choixNbLigne = Console.ReadLine();
                erreurDmdNbLig = !int.TryParse(choixNbLigne, out nbreLigne);
                if (erreurDmdNbLig)
                {
                    Console.WriteLine("Erreur! Veuillez entrer un nombre.");
                }
                else
                {
                    if (nbreLigne < 6)
                    {
                        erreurDmdNbLig = true;
                        Console.WriteLine("Erreur! Une grille de Puissance 4 possède au moins 6 lignes.");
                    }
                    else
                    {
                        erreurDmdNbLig = false;
                    }
                }
            } while (erreurDmdNbLig);
            
            return nbreLigne;
        }

        /// <summary>
        /// Demande le nombre de colonnes de la grille
        /// </summary>
        /// <returns></returns>
        public static int demandeNbreColonnes()
        {
            bool erreurDmdNbCol = false;
            String choixNbCol;
            int nbreColonne;
            do
            {
                Console.WriteLine("De combien de colonnes est constituée la grille? (Min=7)");
                choixNbCol = Console.ReadLine();
                erreurDmdNbCol = !int.TryParse(choixNbCol, out nbreColonne);
                if (erreurDmdNbCol)
                {
                    Console.WriteLine("Erreur! Veuillez entrer un nombre.");
                }
                else
                {
                    if (nbreColonne < 7)
                    {
                        erreurDmdNbCol = true;
                        Console.WriteLine("Erreur! Une grille de Puissance 4 possède au moins 7 colonnes.");
                    }
                    else
                    {
                        erreurDmdNbCol = false;
                    }
                }
            } while (erreurDmdNbCol);
            
            return nbreColonne;
        }

        /// <summary>
        /// Affiche la grille fournie en parametre
        /// </summary>
        /// <param name="grilleJeu">La grille a afficher</param>
        public static void afficheGrille(Grilles grilleJeu)
        {
            Console.Clear();
            String ligneSepar = "";
            for (int col = 0; col < grilleJeu.NbreColonnes; col++)
            {
                Console.Write(" "+(col+1)+" |");
                ligneSepar += "---|";
            }
            Console.Write("\n");
            Console.WriteLine(ligneSepar);
            for (int i = grilleJeu.NbreLignes - 1; i >= 0; i--)
            {
                for (int j = 0; j <grilleJeu.NbreColonnes; j++)
                {
                    Console.Write(" ");
                    if (grilleJeu.Tableau[j, i].EstVide)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.ForegroundColor = grilleJeu.Tableau[j, i].Contenu.Couleur;
                        Console.Write(grilleJeu.Tableau[j, i].Contenu.Signe);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(" |");
                }
                Console.Write("\n");
                Console.WriteLine(ligneSepar);

            }
        }

        /// <summary>
        /// Indique à qui c'est le tour de jouer
        /// </summary>
        /// <param name="j">Joueur dont c'est le tour de joueur</param>
        public static void afficheInviteJoueur(Joueurs j)
        {
            Console.WriteLine("C'est à " + j.Nom + " de jouer!");
        }

        /// <summary>
        /// Demande dans quelle colonne le joueur veut mettre son jeton
        /// </summary>
        /// <param name="grilleJeu">La grille de jeu</param>
        /// <returns></returns>
        public static int demanderColonne(Grilles grilleJeu)
        {
            String choixColonneT;
            int choixColonneN;
            bool erreurCol = false;
            do
            {
                Console.WriteLine("Dans quel colonne mettre le jeton?");
                
                choixColonneT = Console.ReadLine();
                if (int.TryParse(choixColonneT, out choixColonneN))
                {
                    choixColonneN--;
                    if (0 > choixColonneN || choixColonneN > grilleJeu.NbreColonnes)
                    {
                        erreurCol = true;
                        Console.WriteLine("Erreur! Cette colonne n'existe pas.");
                    }
                    else if (grilleJeu.colonnePleine(choixColonneN))
                    {
                        erreurCol = true;
                        Console.WriteLine("Erreur! Cette colonne est déjà pleine.");
                    }
                    else
                    {
                        erreurCol = false;
                    }
                }
                else
                {
                    erreurCol = true;
                    Console.WriteLine("Erreur! Entrée invalide. Veuillez donner le numéro de la colonne.");
                }
                    

            } while (erreurCol);
            return choixColonneN;
        }

        /// <summary>
        /// Affiche soit que la partie est terminée (aucun gagnant), soit le nom du gagnant
        /// </summary>
        /// <param name="j"></param>
        /// <param name="gagne"></param>
        public static void afficheResultat(Joueurs j, bool gagne = true)
        {
            if (gagne)
            {
                Console.WriteLine("Le joueur " + j.Nom + " a gagné!");
            }
            else
            {
                Console.WriteLine("Partie terminée!");
            }
        }
    }
}
