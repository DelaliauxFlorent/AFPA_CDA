using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Services
{
    /// <summary>
    /// Classe des Services pour les Types de Pizzas
    /// </summary>
    public class TypepizzasServices
    {

        private readonly PizzeriaDbContext _context;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="context">Contexte de connexion à la BDD</param>
        public TypepizzasServices(PizzeriaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande d'ajout d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à ajouter</param>
        public void AddTypepizza(Typepizza a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typepizzas.Add(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de suppression d'un objet de cette classe
        /// </summary>
        /// <param name="a">Objet à supprimer</param>
        public void DeleteTypepizza(Typepizza a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Typepizzas.Remove(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Demande de la liste de tous les objets de cette classe
        /// </summary>
        /// <returns>Liste contenant tous les objets de cette classe</returns>
        public IEnumerable<Typepizza> GetAllTypepizzas()
        {
            return _context.Typepizzas.ToList();
        }

        /// <summary>
        /// Demande d'un objet spécifique à partir de son ID
        /// </summary>
        /// <param name="id">ID de l'objet à retourner</param>
        /// <returns>Objet possédant l'ID indiquée</returns>
        public Typepizza GetTypepizzaById(int id)
        {
            return _context.Typepizzas.FirstOrDefault(a => a.IdTypePizza == id);
        }

        /// <summary>
        /// Demande de mise à jour d'un objet
        /// </summary>
        /// <param name="a"></param>
        public void UpdateTypepizza(Typepizza a)
        {
            _context.SaveChanges();
        }

    }
}
