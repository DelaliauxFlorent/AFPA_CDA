using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    public class TypeingredientsServices
    {

        private readonly PizzeriaDbContext _context;

        public TypeingredientsServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        public void AddTypeingredient(Typeingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typeingredients.Add(a);
            _context.SaveChanges();
        }

        public void DeleteTypeingredient(Typeingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typeingredients.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Typeingredient> GetAllTypeingredients()
        {
            return _context.Typeingredients.Include("Ingredients").ToList();
        }

        public Typeingredient GetTypeingredientById(int id)
        {
            return _context.Typeingredients.Include("Ingredients").FirstOrDefault(a => a.IdTypeIngredient == id);
        }

        public void UpdateTypeingredient(Typeingredient a)
        {
            _context.SaveChanges();
        }

    }
}
