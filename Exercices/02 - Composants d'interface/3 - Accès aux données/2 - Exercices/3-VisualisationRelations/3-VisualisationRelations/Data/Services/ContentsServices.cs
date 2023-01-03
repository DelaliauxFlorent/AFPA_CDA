using _3_VisualisationRelations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelations.Data.Services
{
    public class ContentsServices
    {

        private readonly MyDbContext _context;

        public ContentsServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddContent(Content a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Contents.Add(a);
            _context.SaveChanges();
        }

        public void DeleteContent(Content a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Contents.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Content> GetAllContents()
        {
            return _context.Contents.ToList();
        }

        public Content GetContentById(int id)
        {
            return _context.Contents.FirstOrDefault(a => a.IdContent == id);
        }

        public void UpdateContent(Content a)
        {
            _context.SaveChanges();
        }

    }
}
