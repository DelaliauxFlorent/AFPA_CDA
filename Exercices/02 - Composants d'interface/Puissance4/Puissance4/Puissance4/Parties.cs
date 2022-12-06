using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Parties
    {
        public static int NbreJoueurs { get; set; }
        public int NbAligne { get; set; }
        public Joueurs[] ListeJoueurs { get; set; }

        public static int Mode { get; set; }

        /// <summary>
        /// Initialise la partie
        /// </summary>
        /// <returns>La grille de jeu</returns>
        private Grilles initPartie()
        {
            int nbreligne = Affichages.demandeNbreLignes();
            int nbreColonne = Affichages.demandeNbreColonnes();

            Grilles grilleJeu = new Grilles(nbreligne, nbreColonne);

            NbAligne = Affichages.demandeNbreAligne(grilleJeu);
            NbreJoueurs = Affichages.demandeNbreJoueurs();
            ListeJoueurs = new Joueurs[NbreJoueurs];
            for (int i = 0; i < NbreJoueurs; i++)
            {
                ListeJoueurs[i] = Affichages.demandeInfoJoueur(i);
            }

            //foreach (Joueurs player in ListeJoueurs)
            //{
            //    player.afficherJoueur();
            //}

            return grilleJeu;
        }

        /// <summary>
        /// Détermine à qui c'est le tour de jouer
        /// </summary>
        /// <param name="j">Joueur ayant joué précedemment</param>
        /// <returns>Le joueur dont c'est le tour</returns>
        public Joueurs prochainJoueur(Joueurs j = null)
        {
            if (j == null)
            {
                Random rnd = new Random();
                return ListeJoueurs[rnd.Next(NbreJoueurs)];
            }
            return ListeJoueurs[(j.Num + 1) % NbreJoueurs];
        }

        /// <summary>
        /// Vérifie si la partie est gagné
        /// </summary>
        /// <param name="grilleJeu">Grille de jeu</param>
        /// <param name="colonne">Absice du jeton</param>
        /// <param name="ligne">Ordonné du jeton</param>
        /// <returns></returns>
        public bool estGagne(Grilles grilleJeu, int colonne, int ligne)
        {
            int aDroite = grilleJeu.estAligne(colonne, ligne, 1, 0);
            int aGauche = grilleJeu.estAligne(colonne, ligne, -1, 0);
            int enHaut = grilleJeu.estAligne(colonne, ligne, 0, 1);
            int enBas = grilleJeu.estAligne(colonne, ligne, 0, -1);
            int hautDroit = grilleJeu.estAligne(colonne, ligne, 1, 1);
            int basGauche = grilleJeu.estAligne(colonne, ligne, -1, -1);
            int hautGauche = grilleJeu.estAligne(colonne, ligne, -1, 1);
            int basDroit = grilleJeu.estAligne(colonne, ligne, 1, -1);
            int horiz = aDroite + aGauche - 1;
            int vert = enHaut + enBas - 1;
            int diagM = basGauche + hautDroit - 1;
            int diagD = hautGauche + basDroit - 1;
            return (horiz >= NbAligne || vert >= NbAligne || diagD >= NbAligne || diagM >= NbAligne);
        }

        /// <summary>
        /// Lance la partie
        /// </summary>
        public void lancerPartie()
        {
            Grilles grilleJeu = initPartie();
            Joueurs joueurActu = null;
            bool gagne = false;
            bool plein = false;
            do
            {
                Affichages.afficheGrille(grilleJeu);
                joueurActu = prochainJoueur(joueurActu);
                Affichages.afficheInviteJoueur(joueurActu);
                int colonneJouee = Affichages.demanderColonne(grilleJeu);
                int ligneJouee = grilleJeu.premVide(colonneJouee);
                grilleJeu.Tableau[colonneJouee, ligneJouee].estJouable(joueurActu);
                gagne = estGagne(grilleJeu, colonneJouee, ligneJouee);
                plein = grilleJeu.estPleine();
            } while (!plein && !gagne);
            Affichages.afficheGrille(grilleJeu);
            Affichages.afficheResultat(joueurActu, gagne);
        }
    }
}
