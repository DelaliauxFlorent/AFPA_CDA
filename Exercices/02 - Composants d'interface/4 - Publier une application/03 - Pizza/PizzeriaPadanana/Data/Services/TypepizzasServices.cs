using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    public class TypepizzasServices
    {

        private readonly PizzeriaDbContext _context;

        public TypepizzasServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        public void AddTypepizza(Typepizza a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typepizzas.Add(a);
            _context.SaveChanges();
        }

        public void DeleteTypepizza(Typepizza a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typepizzas.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Typepizza> GetAllTypepizzas()
        {
            return _context.Typepizzas.ToList();
        }

        public Typepizza GetTypepizzaById(int id)
        {
            return _context.Typepizzas.FirstOrDefault(a => a.IdTypePizza == id);
        }

        public void UpdateTypepizza(Typepizza a)
        {
            _context.SaveChanges();
        }

    }
}
