using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    public class RolesServices
    {

        private readonly PizzeriaDbContext _context;

        public RolesServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        public void AddRole(Role r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }
            _context.Roles.Add(r);
            _context.SaveChanges();
        }

        public void DeleteRole(Role r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }
            _context.Roles.Remove(r);
            _context.SaveChanges();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.IdRole == id);
        }

        public void UpdateRole(Role r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }
            _context.SaveChanges();
        }
    }
}
