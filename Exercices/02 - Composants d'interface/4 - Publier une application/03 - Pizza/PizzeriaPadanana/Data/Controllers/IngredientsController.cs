using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PizzeriaPadanana.Data.DTOs;
using PizzeriaPadanana.Data.POCOs;
using PizzeriaPadanana.Data.Profiles;
using PizzeriaPadanana.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Controllers
{
    /// <summary>
    /// Classe des controllers pour les Ingrédients
    /// </summary>
    public class IngredientsController : ControllerBase
    {

        private readonly IngredientsServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="_context"></param>
        public IngredientsController(PizzeriaDbContext _context)
        {
            _service = new IngredientsServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<IngredientsProfile>();
                cfg.AddProfile<TypeingredientsProfile>();
                cfg.AddProfile<TypepizzasProfile>();
            });
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>La liste de tous les objets mappés au format choisi.</returns>
        public IEnumerable<IngredientDTOAvecType> GetAllIngredients()
        {
            var listObjets = _service.GetAllIngredients();
            return _mapper.Map<IEnumerable<IngredientDTOAvecType>>(listObjets);
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>Retourne l'objet voulu s'il existe, un objet vide sinon.</returns>
        public Ingredient GetIngredientById(int id)
        {
            var obj = _service.GetIngredientById(id);
            if (obj != null)
            {
                return obj;
            }
            return new Ingredient();
        }

        /// <summary>
        /// Créer un oobjet
        /// </summary>
        /// <param name="ingr"></param>
        public void CreateIngredient(IngredientDTOAvecType objetPasse)
        {
            Ingredient obj = _mapper.Map<Ingredient>(objetPasse);
            //on ajoute l'objet à la base de données
            _service.AddIngredient(obj);
        }

        /// <summary>
        /// Mettre à jour un objet
        /// </summary>
        /// <param name="ingr"></param>
        /// <returns>Retourne 0 si la modification s'est bien passée, -1 sinon.</returns>
        public int UpdateIngredient(Ingredient obj)
        {
            var objFromRepo = _service.GetIngredientById(obj.IdIngredient);
            if (objFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateIngredient(objFromRepo);
            return 0;
        }

        /// <summary>
        /// Supprimer un objet
        /// </summary>
        /// <param name="id">ID de l'objet que l'on veut supprimer</param>
        /// <returns>Retourne 0 si la suppression s'est bien passée, -1 sinon.</returns>
        public int DeleteIngredient(int id)
        {
            var objModelFromRepo = _service.GetIngredientById(id);
            if (objModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteIngredient(objModelFromRepo);
            return 0;
        }
    }


}
