using System;
using System.Collections.Generic;

namespace Salaries_Salaires
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Commerciaux> ListeComs = new List<Commerciaux>();
            List<Techniciens> ListeTecs = new List<Techniciens>();

            ListeComs.Add(new Vendeurs("Dupond", "Paul  ", 30, 10));
            ListeComs.Add(new Vendeurs("Dupond", "Pierre", 32, 5));
            ListeComs.Add(new Vendeurs("Dupond", "Jacque", 31, 1));
            ListeComs.Add(new Representants("Dupond", "Giselle", 31, 3, 10));
            ListeComs.Add(new Representants("Dupond", "Georges", 30, 2, 8));

            ListeTecs.Add(new Techniciens("Dupond", "Robert", 23, 40));
            ListeTecs.Add(new Techniciens("Dupond", "Raymond", 23, 40));
            ListeTecs.Add(new Interimaires("Dupond", "Jean-Claude", 23,0,75));
            ListeTecs.Add(new Interimaires("Dupond", "Jean-Paul", 23,0,50));
            ListeTecs.Add(new Interimaires("Dupond", "Jean-Marie", 23,0,50));
            ListeTecs.Add(new Interimaires("Dupond", "Jean-Jean", 23,0,0));

            Entreprises ent = new Entreprises("Promo IRIS", ListeComs, ListeTecs);
            ent.AfficherRepartSalaire();
        }
    }
}
