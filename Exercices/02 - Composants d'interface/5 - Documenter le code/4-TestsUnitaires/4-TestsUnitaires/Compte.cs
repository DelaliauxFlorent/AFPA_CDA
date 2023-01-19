using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_TestsUnitaires
{
    /// <summary>
    /// Class Compte
    /// </summary>
    public class Compte
    {
        public const string DebitMontantSuperieurSoldeMessage = "Le montant à débiter est supérieur au solde";
        public const string DebitMontantNegatifMessage = "Le montant à débiter est négatif";

        public string Client { get; set; }
        public double Solde { get; set; }
        /// <summary>
        /// Constructeur de la class Compte
        /// </summary>
        /// <param name="nom">Nom du client</param>
        /// <param name="solde">Montant du solde</param>
        public Compte(string nom, double solde)
        {
            Client = nom;
            Solde = solde;
        }

        /// <summary>
        /// Permet de déduire le montant du solde
        /// </summary>
        /// <param name="montant"></param>
        public void Debit(double montant)
        {
            if (montant > Solde)
            {
                throw new ArgumentOutOfRangeException("montant", montant, DebitMontantSuperieurSoldeMessage);
            }

            if (montant<0)
            {
                throw new ArgumentOutOfRangeException("montant", montant, DebitMontantNegatifMessage);
            }
            //Code incorrect volontairement
            Solde -= montant;
        }

        /// <summary>
        /// Fonction permettant de créditer un solde
        /// </summary>
        /// <param name="montant">Montant de la somme à ajouter au solde</param>
        public void Credit(double montant)
        {
            if (montant<0)
            {
                throw new ArgumentOutOfRangeException("montant");
            }
            Solde += montant;
        }
    }
}
