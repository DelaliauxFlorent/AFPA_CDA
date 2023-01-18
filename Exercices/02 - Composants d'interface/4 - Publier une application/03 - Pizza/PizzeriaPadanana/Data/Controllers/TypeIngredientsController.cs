
using AutoMapper;
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

    public class TypeingredientsController : ControllerBase
    {

        private readonly TypeingredientsServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="_context"></param>
        public TypeingredientsController(PizzeriaDbContext _context)
        {
            _service = new TypeingredientsServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TypeingredientsProfile>();
                cfg.AddProfile<IngredientsProfile>();
            });
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>La liste de tous les objets mappés au format choisi.</returns>
        public IEnumerable<TypeingredientDTO> GetAllTypeingredients()
        {
            var listObjets = _service.GetAllTypeingredients();
            return _mapper.Map<IEnumerable<TypeingredientDTO>>(listObjets);
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>Retourne l'objet voulu s'il existe, un objet vide sinon.</returns>
        public Typeingredient GetTypeingredientById(int id)
        {
            var obj = _service.GetTypeingredientById(id);
            if (obj != null)
            {
                return obj;
            }
            return new Typeingredient();
        }

        /// <summary>
        /// Créer un objet
        /// </summary>
        /// <param name="objetPasse"></param>
        public void CreateTypeingredient(TypeingredientDTO objetPasse)
        {
            Typeingredient obj = _mapper.Map<Typeingredient>(objetPasse);
            //on ajoute l'objet à la base de données
            _service.AddTypeingredient(obj);
        }

        /// <summary>
        /// Mettre à jour un objet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retourne 0 si la modification s'est bien passée, -1 sinon.</returns>
        public int UpdateTypeingredient(TypeingredientDTO obj)
        {
            var objFromRepo = _service.GetTypeingredientById(obj.IdTypeIngredient);
            if (objFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateTypeingredient(objFromRepo);
            return 0;
        }

        /// <summary>
        /// Supprimer un objet
        /// </summary>
        /// <param name="id">ID de l'objet que l'on veut supprimer</param>
        /// <returns>Retourne 0 si la suppression s'est bien passée, -1 sinon.</returns>
        public int DeleteTypeingredient(int id)
        {
            var objModelFromRepo = _service.GetTypeingredientById(id);
            if (objModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteTypeingredient(objModelFromRepo);
            return 0;
        }
    }
}
