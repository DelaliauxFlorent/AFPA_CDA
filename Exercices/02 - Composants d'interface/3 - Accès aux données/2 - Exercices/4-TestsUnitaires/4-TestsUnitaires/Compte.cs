using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_TestsUnitaires
{
    public class Compte
    {
        public const string DebitMontantSuperieurSoldeMessage = "Le montant à débiter est supérieur au solde";
        public const string DebitMontantNegatifMessage = "Le montant à débiter est négatif";

        public string Client { get; set; }
        public double Solde { get; set; }
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
