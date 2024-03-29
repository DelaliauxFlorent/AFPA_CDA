﻿using _3_VisualisationRelationsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Services
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
            return _context.Contents.Include("Command").Include("Product").ToList();
        }

        public Content GetContentByIds(int idProduct, int idCommand)
        {
            return _context.Contents.Include("Command").Include("Product").FirstOrDefault(a => a.IdProduct == idProduct && a.IdCommand==idCommand);
        }
        public List<Content> GetContentByIdProduct(int id)
        {
            return _context.Contents.Where(a => a.IdProduct == id).ToList();
        }
        public List<Content> GetContentByIdCommand(int id)
        {
            return _context.Contents.Where(a => a.IdCommand == id).ToList();
        }

        public void UpdateContent(Content a)
        {
            _context.SaveChanges();
        }

    }
}
