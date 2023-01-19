using System;

/// <summary>
/// Projet TestUnitaire
/// </summary>
namespace _4_TestsUnitaires
{
    /// <summary>
    /// Class Program du projet TestUnitaire
    /// </summary>
    class Program
    {
        /// <summary>
        /// Fonction Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Compte compte = new Compte("Toto", 200);
            compte.Credit(100);
            compte.Debit(50);
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Pour que la console affiche bien le symbole €
            Console.WriteLine("Le nouveau solde est de : {0}€", compte.Solde);
            Console.ReadKey(); // Permet de garder la console ouverte
        }
    }
}
