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
    /// Classe des Services pour les Musiciens
    /// </summary>
    public class MusiciensServices
    {

        private readonly EcfContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public MusiciensServices(EcfContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un objet de cette classe
        /// </summary>
        /// <param name="obj">Objet à ajouter</param>
        public void AddMusicien(Musicien obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Musiciens.Add(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un objet de cette classe
        /// </summary>
        /// <param name="obj">Objet à supprimer</param>
        public void DeleteMusicien(Musicien obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Musiciens.Remove(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de la liste de tous les objets de cette classe
        /// </summary>
        /// <returns>Liste contenant tous les objets de cette classe</returns>
        public IEnumerable<Musicien> GetAllMusiciens()
        {
            // Penser à ajouter les "Include()" nécessaires
            return _context.Musiciens.Include("Groupe").ToList();
        }

        /// <summary>
        /// Demande d'un objet spécifique à partir de son ID
        /// </summary>
        /// <param name="id">ID de l'objet à retourner</param>
        /// <returns>Objet possédant l'ID indiquée</returns>
        public Musicien GetMusicienById(int id)
        {
            // Penser à ajouter les "Include()" nécessaires
            return _context.Musiciens.Include("Groupe").FirstOrDefault(obj => obj.IdMusicien == id);
        }

        /// <summary>
        /// Demande de mise à jour d'un objet
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateMusicien(Musicien obj)
        {
            _context.SaveChanges();
        }

    }

}
