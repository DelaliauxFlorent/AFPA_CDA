using _3_VisualisationRelations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelations.Data.Services
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
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(a => a.IdCommand == id);
        }

        public void UpdateCommand(Command a)
        {
            _context.SaveChanges();
        }

    }
}
