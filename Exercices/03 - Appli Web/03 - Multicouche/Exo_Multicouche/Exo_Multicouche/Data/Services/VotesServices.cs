using Exo_Multicouche.Data.Dtos;
using Exo_Multicouche.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo_Multicouche.Data.Services
{

    /// <summary>
    /// Classe des Services pour les Votes
    /// </summary>
    public class VotesServices
    {

        private readonly McContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public VotesServices(McContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un objet de cette classe
        /// </summary>
        /// <param name="obj">Objet à ajouter</param>
        public void AddVote(Vote obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Votes.Add(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un objet de cette classe
        /// </summary>
        /// <param name="obj">Objet à supprimer</param>
        public void DeleteVote(Vote obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Votes.Remove(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de la liste de tous les objets de cette classe
        /// </summary>
        /// <returns>Liste contenant tous les objets de cette classe</returns>
        public IEnumerable<Vote> GetAllVotes()
        {
            // Penser à ajouter les "Include()" nécessaires
            return _context.Votes.ToList();
        }

        /// <summary>
        /// Demande d'un objet spécifique à partir de son ID
        /// </summary>
        /// <param name="id">ID de l'objet à retourner</param>
        /// <returns>Objet possédant l'ID indiquée</returns>
        public Vote GetVoteById(int id)
        {
            // Penser à ajouter les "Include()" nécessaires
            return _context.Votes.FirstOrDefault(obj => obj.IdVote == id);
        }

        /// <summary>
        /// Demande de mise à jour d'un objet
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateVote(Vote obj)
        {
            _context.SaveChanges();
        }

    }

}
