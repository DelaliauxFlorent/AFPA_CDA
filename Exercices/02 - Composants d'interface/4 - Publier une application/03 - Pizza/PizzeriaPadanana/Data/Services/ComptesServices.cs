using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    /// <summary>
    /// Classe des Services pour les Comptes
    /// </summary>
    public class ComptesServices
    {

        private readonly PizzeriaDbContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public ComptesServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à ajouter</param>
        public void AddCompte(Compte c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.Comptes.Add(c);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à supprimer</param>
        public void DeleteCompte(Compte c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.Comptes.Remove(c);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de la liste de tous les objets de cette classe
        /// </summary>
        /// <returns>Liste contenant tous les objets de cette classe</returns>
        public IEnumerable<Compte> GetAllComptes()
        {
            return _context.Comptes.Include("IdRoleNavigation").ToList();
        }

        /// <summary>
        /// Demande d'un objet spécifique à partir de son ID
        /// </summary>
        /// <param name="id">ID de l'objet à retourner</param>
        /// <returns>Objet possédant l'ID indiquée</returns>
        public Compte GetCompteById(int id)
        {
            return _context.Comptes.FirstOrDefault(c => c.IdCompte == id);
        }

        /// <summary>
        /// Demande de mise à jour d'un objet
        /// </summary>
        /// <param name="a"></param>
        public void UpdateCompte(Compte c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.SaveChanges();
        }
    }
}
