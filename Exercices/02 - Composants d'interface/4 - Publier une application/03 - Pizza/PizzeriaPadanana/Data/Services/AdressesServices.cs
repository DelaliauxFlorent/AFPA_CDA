using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    class AdressesServices
    {

        private readonly PizzeriaDbContext _context;

        public AdressesServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        public void AddAdresse(Adress a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Adresses.Add(a);
            _context.SaveChanges();
        }

        public void DeleteAdresse(Adress a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Adresses.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Adress> GetAllAdresses()
        {
            return _context.Adresses.ToList();
        }

        public Adress GetAdresseById(int id)
        {
            return _context.Adresses.FirstOrDefault(a => a.IdAdresse == id);
        }

        public void UpdateAdresse(Adress a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.SaveChanges();
        }
    }
}
