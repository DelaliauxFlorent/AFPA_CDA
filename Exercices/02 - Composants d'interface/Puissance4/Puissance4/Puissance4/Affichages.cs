using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Affichages
    {
        // Liste des couleurs pour sélection par le joueur
        public static readonly String[] ListeCouleursT = { " 1 - Bleu Foncé", " 2 - Vert Foncé", " 3 - Cyan Foncé", " 4 - Rouge Foncé", " 5 - Magenta Foncé", " 6 - Jaune Foncé", " 7 - Gris", " 8 - Gris Foncé", " 9 - Bleu", "10 - Vert", "11 - Cyan", "12 - Rouge", "13 - Magenta", "14 - Jaune", "15 - Blanc" };

        // Liste des Couleurs au format ConsoleColor pour faciliter enregistrement
        public static readonly ConsoleColor[] consoleColors
            = (ConsoleColor[])ConsoleColor
                  .GetValues(typeof(ConsoleColor));

        /// <summary>
        /// Demande le nombre de joueurs participants
        /// </summary>
        /// <returns>int</returns>
        public static int demandeNbreJoueurs()
        {
            bool erreurDmdNbJ = false;
            int nbJoueur = 2;
            do
            {
                // Demande du nombre de Joueurs
                Console.WriteLine("Nombre de joueurs: ");
                String nbJ = Console.ReadLine();
                if (nbJ != "")
                {
                    // Test si la valeur est un nombre
                    // Si oui => met la valeur en INT dans la variable de retour
                    // Si non => Affiche message d'erreur et boucle
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

        public static void

        /// <summary>
        /// Demande les info d'un joueur spécifique
        /// </summary>
        /// <param name="num">Son ID</param>
        /// <returns>Un joueur avec un ID, un nom, une couleur et un signe</returns>
        public static Joueurs demandeInfoJoueur(int num)
        {
            // Déclaration et initialisation des Checks d'erreurs
            // Si erreur lors de la saisie du nom
            bool erreurNom = false;
            // Si erreur lors de la saisie de la couleur
            bool erreurColor = false;
            // Si erreur lors de la saisie du signe
            bool erreurSigne = false;
            // Si erreur dans l'association Couleur/Signe
            bool erreurColSig = false;

            // Variables pour les ReadLines
            String nomJoueur;
            String choixCouleur;
            String choixSign;

            // Déclaration et initialisation de la couleur et du signe par défaut
            ConsoleColor couleurJoueur = ConsoleColor.Gray;
            char signJoueur = '#';

            // Index pour parcourir les listes de couleurs et de signe de la classe Joueurs
            int indxCheckColSig;

            //
            //Demande du nom
            //
            do
            {
                Console.WriteLine("\nQuel est le nom du joueur " + (num + 1) + "?");
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
            //
            //Demande couleur ET signe
            //
            do
            {
                erreurColSig = false;
                //
                //Demande de la couleur
                //
                do
                {
                    //
                    //Affichage de la liste des couleurs possibles
                    //
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
                            if (i == 10 || i == 13)
                            {
                                Console.Write("\t");
                            }
                            Console.Write("\t| ");
                        }
                    }
                    //
                    // Demande du choix du joueur
                    //
                    Console.WriteLine("\nQuel couleur utiliser (numéro)?");
                    choixCouleur = Console.ReadLine();
                    // Check si le choix est bien un entier
                    // Si oui => 
                    if (int.TryParse(choixCouleur, out int ChoixColorNum))
                    {
                        // Vérification que le choix est possible
                        // Si c'est le cas, (re)mise du code d'erreur à false
                        // et assignation de la couleur à la variable qui sera
                        // utilisé pour créer le joueur retourné 
                        if (ChoixColorNum > 0 && ChoixColorNum < 16)
                        {
                            erreurColor = false;
                            couleurJoueur = consoleColors[ChoixColorNum];
                        }
                        // Sinon, code d'erreur à true et affichage du message
                        // d'erreur indiquant le problème
                        else
                        {
                            erreurColor = true;
                            Console.WriteLine("Erreur! Ce numéro ne correspond à aucune couleur.");
                        }

                    }
                    // Sinon, code d'erreur à true et affichage du message
                    // d'erreur indiquant le problème
                    else
                    {
                        erreurColor = true;
                        Console.WriteLine("Erreur! Entrée invalide, veuillez donner le numéro correspondant à la couleur voulue.");
                    }
                    // On boucle tant qu'il y a un problème
                } while (erreurColor);

                //
                // Demande du caractère
                //
                do
                {
                    Console.WriteLine("Quel caractère?");
                    choixSign = Console.ReadLine();
                    // On vérifie si le joueur n'a bien entré qu'un seul caractère
                    if (choixSign.Length == 1)
                    {
                        // Si oui => (re)mise du code d'erreur à false
                        // et assignation du signe à la variable qui sera
                        // utilisé pour créer le joueur retourné 
                        char.TryParse(choixSign, out signJoueur);
                        erreurSigne = false;
                    }
                    else
                    {
                        // Sinon, code d'erreur à true et message explicant pourquoi
                        erreurSigne = true;
                        Console.WriteLine("Erreur! Il vous faut un et un seul caractère.");
                    }
                    // On boucle tant qu'il y a un problème
                } while (erreurSigne);

                //
                // Après le premier joueur, on doit faire un check supplémentaire
                //
                if (num > 0)
                {
                    // Initialise l'index à 0
                    indxCheckColSig = 0;
                    // Boucle tant qu'il n'y a pas d'erreur et
                    // qu'on est pas à la fin des listes
                    do
                    {
                        // Check si, à l'index actuel, un autre joueur
                        // a déjà choisie cette association
                        if (Joueurs.ListeCouleurs[indxCheckColSig] == couleurJoueur && Joueurs.ListeSignes[indxCheckColSig] == signJoueur)
                        {
                            // Si c'est le cas, on passe le code d'erreur à true
                            erreurColSig = true;
                            // On Clear() la console pour nettoyer l'affichage
                            Console.Clear();
                            // Et on met le message d'erreur indiquant le problème
                            Console.WriteLine("Erreur! Cette association Signe/Couleur est déjà utilisé par un autre joueur. Veuillez en changer.");
                        }
                        // Incrémentation de l'index
                        indxCheckColSig++;
                    } while (!erreurColSig && indxCheckColSig < num);
                }
                //
                // Si l'association Couleur/Signe à déjà été choisie
                // On retourne au choix de la couleur
                //
            } while (erreurColSig);
            //
            // Si aucun problèmes, création d'un nouvel objet de
            // la classe Joueurs que l'on retourne
            //
            Joueurs player = new Joueurs(num, nomJoueur, couleurJoueur, signJoueur);
            return player;
        }

        /// <summary>
        /// Demande le nombre de jeton devant être alignés pour que le joueur gagne
        /// </summary>
        /// <returns>int</returns>
        public static int demandeNbreAligne(Grilles grilleJeu)
        {
            // Déclaration et initialisation du Check d'erreur
            bool erreurDmdNbAli = false;
            // Déclaration de la variable pour le ReadLine
            String nbAlignT;
            // Déclaration de la variable de retour
            int nbAligne;

            // Tant qu'il y a un problème, on boucle sur...
            do
            {
                // Afficher la demande
                Console.WriteLine("Combien de jetons identiques doivent-ils être alignés pour remporter la partie?");
                nbAlignT = Console.ReadLine();
                // Test si l'utilisateur a bien entré un entier
                erreurDmdNbAli = !int.TryParse(nbAlignT, out nbAligne);
                if (erreurDmdNbAli)
                {
                    // Affichage du message d'erreur si pas un entier
                    Console.WriteLine("Erreur! Veuillez entrer un nombre.");
                }
                else
                {
                    // Si un entier, vérifier si pas trop petit (trop simple)
                    if (nbAligne < 3)
                    {
                        erreurDmdNbAli = true;
                        Console.WriteLine("Erreur! Cette valeur est trop petite.");
                    }
                    // ou trop grand (pourrait jamais gagné ou seulement dans une condition/direction)
                    // 
                    else if (nbAligne > Math.Min(grilleJeu.NbreColonnes, grilleJeu.NbreLignes))
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
            // Déclaration et initialisation du Check d'erreur
            bool erreurDmdNbLig = false;
            // Déclaration de la variable pour le ReadLine
            String choixNbLigne;
            // Déclaration de la variable de retour
            int nbreLigne;

            do
            {
                // Affichage de la demande
                Console.WriteLine("De combien de lignes est constituée la grille? (Min=6)");
                choixNbLigne = Console.ReadLine();
                // Test si bien un entier
                erreurDmdNbLig = !int.TryParse(choixNbLigne, out nbreLigne);
                if (erreurDmdNbLig)
                {
                    // Si non, affichage du message d'erreur
                    Console.WriteLine("Erreur! Veuillez entrer un nombre.");
                }
                else
                {
                    // Si oui, vérification que la valeur n'est pas trop petite
                    if (nbreLigne < 6)
                    {
                        erreurDmdNbLig = true;
                        Console.WriteLine("Erreur! Une grille de Puissance 4 possède au moins 6 lignes.");
                    }
                    // Ni trop grande
                    else if (nbreLigne > Grilles.maxLignes)
                    {
                        erreurDmdNbLig = true;
                        Console.WriteLine("Erreur! N'exagérez pas.");
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
            // Déclaration et initialisation du Check d'erreur
            bool erreurDmdNbCol = false;
            // Déclaration de la variable pour le ReadLine
            String choixNbCol;
            // Déclaration de la variable de retour
            int nbreColonne;
            do
            {
                // Affichage de la demande
                Console.WriteLine("De combien de colonnes est constituée la grille? (Min=7)");
                choixNbCol = Console.ReadLine();
                // Test si bien un entier
                erreurDmdNbCol = !int.TryParse(choixNbCol, out nbreColonne);
                if (erreurDmdNbCol)
                {
                    // Si non, affichage du message d'erreur
                    Console.WriteLine("Erreur! Veuillez entrer un nombre.");
                }
                else
                {
                    // Si oui, vérification que la valeur n'est pas trop petite
                    if (nbreColonne < 7)
                    {
                        erreurDmdNbCol = true;
                        Console.WriteLine("Erreur! Une grille de Puissance 4 possède au moins 7 colonnes.");
                    }
                    // Ni trop grande
                    else if (nbreColonne > Grilles.maxColonnes)
                    {
                        erreurDmdNbCol = true;
                        Console.WriteLine("Erreur! N'exagérez pas.");
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
            // Vidage de la console
            Console.Clear();
            // Préparation des lignes de séparation
            String ligneSepar = "";
            
            //
            // Création dee l'"entête" de la grille de jeu
            //
            for (int col = 0; col < grilleJeu.NbreColonnes; col++)
            {
                Console.Write(" " + (col + 1) + " |");
                ligneSepar += "---+";
            }
            ligneSepar= ligneSepar.Substring(0, ligneSepar.Length-1);
            ligneSepar += "┤";
            Console.Write("\n");
            Console.WriteLine(ligneSepar);

            //
            // Parcours des lignes et des colonnes pour avoir
            // la position [0;0] en bas à gauche
            //
            for (int i = grilleJeu.NbreLignes - 1; i >= 0; i--)
            {
                for (int j = 0; j < grilleJeu.NbreColonnes; j++)
                {
                    // Une case consiste en un espace
                    Console.Write(" ");
                    // Ajout d'un espace si case vide
                    if (grilleJeu.Tableau[j, i].EstVide)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        // Si case non-vide, on change la couleur
                        // d'affichage du texte par la valeur
                        // propre au joueur concerné
                        Console.ForegroundColor = grilleJeu.Tableau[j, i].Contenu.Couleur;
                        // On met le signe qu'il faut
                        Console.Write(grilleJeu.Tableau[j, i].Contenu.Signe);
                        // Puis on remet la couleur de texte par défaut
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    // Et on finit la case par un espace et la séparation de colonne
                    Console.Write(" |");
                }
                // Retour à la ligne et ajout de la ligne de séparation
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
            // Déclaration et initialisation du Check d'erreur
            bool erreurCol = false;
            // Déclaration de la variable pour le ReadLine
            String choixColonneT;
            // Déclaration de la variable de retour
            int choixColonneN;
            do
            {
                Console.WriteLine("Dans quel colonne mettre le jeton?");

                choixColonneT = Console.ReadLine();
                // On vérifie que l'utilisateur donne bien un entier
                if (int.TryParse(choixColonneT, out choixColonneN))
                {
                    // Si oui, on décrémente de 1 cette valeur
                    // (différence d'index d'origine)
                    choixColonneN--;
                    // Si l'entier est négatif ou supérieur au nombre de colonnes
                    if (0 > choixColonneN || choixColonneN > grilleJeu.NbreColonnes)
                    {
                        // Erreur indiquant la non-existance du choix
                        erreurCol = true;
                        Console.WriteLine("Erreur! Cette colonne n'existe pas.");
                    }
                    // Si la colonne est possible mais déjà pleine
                    else if (grilleJeu.colonnePleine(choixColonneN))
                    {
                        // Erreur Colonne pleine
                        erreurCol = true;
                        Console.WriteLine("Erreur! Cette colonne est déjà pleine.");
                    }
                    else
                    {
                        // Sinon, tout est bon
                        erreurCol = false;
                    }
                }
                else
                {
                    // Si l'utilisateur a donné autre chose qu'un entier
                    // Erreur
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
