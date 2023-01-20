using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    /// <summary>
    /// Classe des Services pour les Rôles
    /// </summary>
    public class RolesServices
    {

        private readonly PizzeriaDbContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public RolesServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à ajouter</param>
        public void AddRole(Role r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }
            _context.Roles.Add(r);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à supprimer</param>
        public void DeleteRole(Role r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }
            _context.Roles.Remove(r);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de la liste de tous les objets de cette classe
        /// </summary>
        /// <returns>Liste contenant tous les objets de cette classe</returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        /// <summary>
        /// Demande d'un objet spécifique à partir de son ID
        /// </summary>
        /// <param name="id">ID de l'objet à retourner</param>
        /// <returns>Objet possédant l'ID indiquée</returns>
        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.IdRole == id);
        }

        /// <summary>
        /// Demande de mise à jour d'un objet
        /// </summary>
        /// <param name="a"></param>
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
