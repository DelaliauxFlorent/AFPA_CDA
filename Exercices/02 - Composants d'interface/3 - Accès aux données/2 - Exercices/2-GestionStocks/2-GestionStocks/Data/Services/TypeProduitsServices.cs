using _2_GestionStocks.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Data.Services
{
    class TypeProduitsServices
    {

        private readonly MyDbContext _context;

        public TypeProduitsServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddTypesProduit(Typesproduit a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typesproduits.Add(a);
            _context.SaveChanges();
        }

        public void DeleteTypesProduit(Typesproduit a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typesproduits.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Typesproduit> GetAllTypesproduits()
        {
            return _context.Typesproduits.ToList();
        }

        public Typesproduit GetTypesProduitById(int id)
        {
            return _context.Typesproduits.FirstOrDefault(a => a.IdTypeProduit == id);
        }

        public void UpdateTypesProduit(Typesproduit a)
        {
            _context.SaveChanges();
        }

    }
}
