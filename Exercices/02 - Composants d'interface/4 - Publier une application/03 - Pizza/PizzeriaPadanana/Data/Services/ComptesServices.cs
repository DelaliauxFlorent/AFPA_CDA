using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    public class ComptesServices
    {

        private readonly PizzeriaDbContext _context;

        public ComptesServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        public void AddCompte(Compte c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.Comptes.Add(c);
            _context.SaveChanges();
        }

        public void DeleteCompte(Compte c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.Comptes.Remove(c);
            _context.SaveChanges();
        }

        public IEnumerable<Compte> GetAllComptes()
        {
            return _context.Comptes.Include("IdRoleNavigation").ToList();
        }

        public Compte GetCompteById(int id)
        {
            return _context.Comptes.FirstOrDefault(c => c.IdCompte == id);
        }

        public void UpdateCompte(Compte c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.SaveChanges();
        }
    }
}
