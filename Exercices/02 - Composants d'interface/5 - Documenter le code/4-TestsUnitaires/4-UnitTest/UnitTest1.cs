using NUnit.Framework;
using System;
using _4_TestsUnitaires;

namespace _4_UnitTest
{
    public class CompteTest
    {
        Compte compte;

        /// <summary>
        /// Setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            double soldeDepart = 11.99;
            compte = new Compte("Mr Toto", soldeDepart);
        }

        /// <summary>
        /// Test du Debit, cas Montant Valide
        /// </summary>
        [Test]
        public void Debit_MontantValide()
        {
            // Arrange
            double montantDebite = 4.55;
            double attendu = 7.44;

            // Act
            compte.Debit(montantDebite);

            // Assert
            double soldeActuel = compte.Solde;
            Assert.AreEqual(attendu, soldeActuel, 0.001, "Compte mal débité");
        }

        /// <summary>
        /// Test du Debit, cas Montant Négatif
        /// </summary>
        [Test]
        public void Debit_MontantNegatif()
        {
            // Arrange
            double montantDebite = -4;

            // Act et Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Debit(montantDebite));
        }

        /// <summary>
        /// Test du Debit, cas Montant > Solde
        /// </summary>
        [Test]
        public void Debit_MontantSuperieurSolde()
        {
            // Arrange
            double montantDebite = -44.55;

            // Act et Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Debit(montantDebite));
        }
    }
}