using _3_VisualisationRelationsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Services
{
    public class PersonsServices
    {

        private readonly MyDbContext _context;

        public PersonsServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddPerson(Person a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Persons.Add(a);
            _context.SaveChanges();
        }

        public void DeletePerson(Person a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Persons.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Persons.FirstOrDefault(a => a.IdPerson == id);
        }

        public void UpdatePerson(Person a)
        {
            _context.SaveChanges();
        }

    }
}
