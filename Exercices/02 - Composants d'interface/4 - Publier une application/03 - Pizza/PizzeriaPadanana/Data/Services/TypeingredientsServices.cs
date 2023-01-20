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
    /// Services portant sur les types d'ingrédients
    /// </summary>
    public class TypeingredientsServices
    {

        private readonly PizzeriaDbContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public TypeingredientsServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un type d'ingrédient
        /// </summary>
        /// <param name="a">Type d'ingrédient à ajouter</param>
        public void AddTypeingredient(Typeingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typeingredients.Add(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un type d'ingredient
        /// </summary>
        /// <param name="a">Type d'ingrédient à supprimer</param>
        public void DeleteTypeingredient(Typeingredient a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typeingredients.Remove(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Récupère la liste de tous les types d'ingrédients
        /// </summary>
        /// <returns>La liste de tous les types d'ingrédients</returns>
        public IEnumerable<Typeingredient> GetAllTypeingredients()
        {
            return _context.Typeingredients.Include("Ingredients").ToList();
        }

        /// <summary>
        /// Récupérer un type d'ingrédient précis, par son ID
        /// </summary>
        /// <param name="id">ID du type d'ingrédient que l'on veut récupérer</param>
        /// <returns>Le type d'ingrédient voulu</returns>
        public Typeingredient GetTypeingredientById(int id)
        {
            return _context.Typeingredients.Include("Ingredients").FirstOrDefault(a => a.IdTypeIngredient == id);
        }

        /// <summary>
        /// Modification d'un type d'ingrédient
        /// </summary>
        /// <param name="a">Le type d'ingrédient modifié</param>
        public void UpdateTypeingredient(Typeingredient a)
        {
            _context.SaveChanges();
        }

    }
}
