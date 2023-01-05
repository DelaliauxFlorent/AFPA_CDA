using System;

namespace _4_TestsUnitaires
{
    class Program
    {
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
