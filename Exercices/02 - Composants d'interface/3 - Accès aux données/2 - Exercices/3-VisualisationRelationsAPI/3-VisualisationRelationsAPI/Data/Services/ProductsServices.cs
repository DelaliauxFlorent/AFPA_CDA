using _3_VisualisationRelationsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Services
{
    public class ProductsServices
    {

        private readonly MyDbContext _context;

        public ProductsServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Products.Add(a);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Products.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(a => a.IdProduct == id);
        }

        public void UpdateProduct(Product a)
        {
            _context.SaveChanges();
        }

    }
}
