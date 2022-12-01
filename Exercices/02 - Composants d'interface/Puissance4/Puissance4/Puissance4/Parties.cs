using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Parties
    {
        public int NbreJoueurs { get; set; }
        public int NbAligne { get; set; }
        public Joueurs[] ListeJoueurs { get; set; }

        private Grilles initPartie()
        {
            int nbreligne = Affichages.demandeNbreLignes();
            int nbreColonne = Affichages.demandeNbreColonnes();
            Grilles grilleJeu = new Grilles(nbreligne, nbreColonne);

            NbAligne = Affichages.demandeNbreAligne();
            NbreJoueurs = Affichages.demandeNbreJoueurs();
            ListeJoueurs = new Joueurs[NbreJoueurs];
            for (int i = 0; i < NbreJoueurs; i++)
            {
                ListeJoueurs[i] = Affichages.demandeInfoJoueur(i + 1);
            }

            foreach (Joueurs player in ListeJoueurs)
            {
                player.afficherJoueur();
            }
            return grilleJeu;
        }

        public int prochainJoueur(Joueurs j = null)
        {
            if (j == null)
            {
                Random rnd = new Random();
                return rnd.Next(NbreJoueurs);
            }
            return (j.Num + 1) % NbreJoueurs;
        }

        public void lancerPartie()
        {
            Grilles grilleJeu = initPartie();
            int joueurActu;
            bool gagne = false;
            bool plein = false;
            do
            {
                Affichages.afficheGrille(grilleJeu);
                joueurActu = prochainJoueur();
                Affichages.afficheInviteJoueur(joueurActu);
            } while (!plein && !gagne);
        }
    }
}
