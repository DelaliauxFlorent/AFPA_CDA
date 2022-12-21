using _3_CreerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_CreerAPI.Data.Services
{
    public class PersonnesServices
    {
        private readonly MyDbContext _context;
        public PersonnesServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddPersonnes(Personne p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Personnes.Add(p);
            _context.SaveChanges();
        }

        public void DeletePersonnes(Personne p)
        {
            // Si l'objet est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // On met à jour le context
            _context.Personnes.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Personne> GetAllPersonnes()
        {
            return _context.Personnes.ToList();
        }

        public Personne GetPersonneById(int id)
        {
            return _context.Personnes.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePersonne(Personne p)
        {
            //nothing
            // On va mettre à jour le context dans le controller par mapping et passer les modifs à la base
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.SaveChanges();
        }
    }
}
