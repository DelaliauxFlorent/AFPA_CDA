using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    /// <summary>
    /// Classe des Services pour les Ingrédients
    /// </summary>
    public class IngredientsServices
    {

        private readonly PizzeriaDbContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public IngredientsServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à ajouter</param>
        public void AddIngredient(Ingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Ingredients.Add(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à supprimer</param>
        public void DeleteIngredient(Ingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Ingredients.Remove(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de la liste de tous les objets de cette classe
        /// </summary>
        /// <returns>Liste contenant tous les objets de cette classe</returns>
        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.Include("IdTypeIngredientNavigation").ToList();
        }

        /// <summary>
        /// Demande d'un objet spécifique à partir de son ID
        /// </summary>
        /// <param name="id">ID de l'objet à retourner</param>
        /// <returns>Objet possédant l'ID indiquée</returns>
        public Ingredient GetIngredientById(int id)
        {
            return _context.Ingredients.FirstOrDefault(a => a.IdIngredient == id);
        }

        /// <summary>
        /// Demande de mise à jour d'un objet
        /// </summary>
        /// <param name="a"></param>
        public void UpdateIngredient(Ingredient a)
        {
            _context.SaveChanges();
        }

    }
}
