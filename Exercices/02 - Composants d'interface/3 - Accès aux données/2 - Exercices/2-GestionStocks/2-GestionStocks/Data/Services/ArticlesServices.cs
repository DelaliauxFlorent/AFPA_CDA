using _2_GestionStocks.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Data.Services
{
    class ArticlesServices
    {
        private readonly MyDbContext _context;

        public ArticlesServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddArticle(Article a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Articles.Add(a);
            _context.SaveChanges();
        }

        public void DeleteArticle(Article a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Articles.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.IdArticle == id);
        }

        public void UpdateArticle(Article a)
        {
            _context.SaveChanges();
        }
    }
}
