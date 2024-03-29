﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Grilles
    {
        public static readonly int maxLignes = 20;
        public static readonly int maxColonnes = 20;
        public static readonly int minLignes = 6;
        public static readonly int minColonnes = 7;


        /// <summary>
        /// Constructeur de la grille
        /// </summary>
        /// <param name="nbreLignes">Nombre de lignes de la grille</param>
        /// <param name="nbreColonnes">Nombre de colonne de la grille</param>
        public Grilles(int nbreLignes, int nbreColonnes)
        {
            NbreLignes = nbreLignes;
            NbreColonnes = nbreColonnes;
            Tableau = new Cases[nbreColonnes, nbreLignes];
            // On rempli la grille de cases vides
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

        /// <summary>
        /// Check si la colonne est déjà pleine
        /// </summary>
        /// <param name="colonne">Numéro de la colonne a checker</param>
        /// <returns></returns>
        public bool colonnePleine(int colonne)
        {
            return !(Tableau[colonne, NbreLignes - 1].EstVide);
        }

        /// <summary>
        /// Check si la grille est déjà entièrement remplie
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Récupère la valeur de la première ligne vide de la colonne
        /// </summary>
        /// <param name="colonne">Le numéro de la colonne (commence à 1)</param>
        /// <returns>Soit la valeur de la première ligne vide, soit -1 en cas d'erreur/colonne pleine</returns>
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

        /// <summary>
        /// Check dans une direction à partir du jeton placé pour savoir le nombre de jeton aligné par là
        /// </summary>
        /// <param name="colonne">"Position X" du jeton placé</param>
        /// <param name="ligne">"Position Y" du jeton placé</param>
        /// <param name="dirCol">Direction du mouvement sur les absices</param>
        /// <param name="dirLig">Direction du mouvement sur les ordonnées</param>
        /// <returns></returns>
        public int estAligne(int colonne, int ligne, int dirCol, int dirLig)
        {
            // Calcul des nouvelles coordonnées
            int newCol = colonne + dirCol;
            int newLig = ligne + dirLig;

            // Si la nouvelle coordonné correspond à une case possible
            // ET que cette dernière n'est pas vide
            if(0<=newCol && newCol < NbreColonnes && 0<= newLig && newLig < NbreLignes && !Tableau[newCol, newLig].EstVide)
            {
                // Récupération des Joueurs pour la case actuelle et la case suivante
                Joueurs joueurActu = Tableau[colonne, ligne].Contenu;
                Joueurs joueurDir = Tableau[newCol, newLig].Contenu;

                //// Récupération des signes pour la case actuelle et la case suivante
                //char signeActu = Tableau[colonne, ligne].Contenu.Signe;
                //char signeDir = Tableau[newCol, newLig].Contenu.Signe;
                //// Récupération des couleurs pour la case actuelle et la case suivante
                //ConsoleColor couleurActu = Tableau[colonne, ligne].Contenu.Couleur;
                //ConsoleColor couleurDir = Tableau[newCol, newLig].Contenu.Couleur;
                if (joueurActu == joueurDir)
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
