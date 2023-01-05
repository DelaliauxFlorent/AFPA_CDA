using _3_VisualisationRelationsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Services
{
    public class CommandsServices
    {

        private readonly MyDbContext _context;

        public CommandsServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddCommand(Command a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Commands.Add(a);
            _context.SaveChanges();
        }

        public void DeleteCommand(Command a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Commands.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.Include("Contents.Product").ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.Include("Contents.Product").FirstOrDefault(a => a.IdCommand == id);
        }

        public void UpdateCommand(Command a)
        {
            _context.SaveChanges();
        }

    }
}
