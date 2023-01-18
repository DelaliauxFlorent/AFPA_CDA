using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    public class IngredientsServices
    {

        private readonly PizzeriaDbContext _context;

        public IngredientsServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        public void AddIngredient(Ingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Ingredients.Add(a);
            _context.SaveChanges();
        }

        public void DeleteIngredient(Ingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Ingredients.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.Include("IdTypeIngredientNavigation").ToList();
        }

        public Ingredient GetIngredientById(int id)
        {
            return _context.Ingredients.FirstOrDefault(a => a.IdIngredient == id);
        }

        public void UpdateIngredient(Ingredient a)
        {
            _context.SaveChanges();
        }

    }
}
