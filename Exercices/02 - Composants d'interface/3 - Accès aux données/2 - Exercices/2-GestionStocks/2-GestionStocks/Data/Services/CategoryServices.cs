using _2_GestionStocks.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Data.Services
{
    class CategoryServices
    {

        private readonly MyDbContext _context;

        public CategoryServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Categories.Add(a);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Categories.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategorys()
        {
            return _context.Categories.Include("TypesProduit").ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Include("TypesProduit").FirstOrDefault(a => a.IdCategorie == id);
        }

        public void UpdateCategory(Category a)
        {
            _context.SaveChanges();
        }

    }
}
