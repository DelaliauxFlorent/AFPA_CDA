using ECF.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECF.Data.Services
{

    /// <summary>
    /// Classe des Services pour les Groupes
    /// </summary>
    public class GroupesServices
    {

        private readonly EcfContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public GroupesServices(EcfContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un objet de cette classe
        /// </summary>
        /// <param name="obj">Objet à ajouter</param>
        public void AddGroupe(Groupe obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Groupes.Add(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un objet de cette classe
        /// </summary>
        /// <param name="obj">Objet à supprimer</param>
        public void DeleteGroupe(Groupe obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Groupes.Remove(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de la liste de tous les objets de cette classe
        /// </summary>
        /// <returns>Liste contenant tous les objets de cette classe</returns>
        public IEnumerable<Groupe> GetAllGroupes()
        {
            // Penser à ajouter les "Include()" nécessaires
            return _context.Groupes.Include("ListeMusiciens").ToList();
        }

        /// <summary>
        /// Demande d'un objet spécifique à partir de son ID
        /// </summary>
        /// <param name="id">ID de l'objet à retourner</param>
        /// <returns>Objet possédant l'ID indiquée</returns>
        public Groupe GetGroupeById(int id)
        {
            // Penser à ajouter les "Include()" nécessaires
            return _context.Groupes.Include("ListeMusiciens").FirstOrDefault(obj => obj.IdGroupe == id);
        }

        /// <summary>
        /// Demande de mise à jour d'un objet
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateGroupe(Groupe obj)
        {
            _context.SaveChanges();
        }

    }

}
