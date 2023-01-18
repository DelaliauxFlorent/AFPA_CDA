using _2_GestionStocks.Data;
using _2_GestionStocks.Data.Dtos;
using _2_GestionStocks.Data.Profiles;
using _2_GestionStocks.Data.Services;
using _2_GestionStocks.Models.DbModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Controller
{
    //class ArticlesController
    //{
    //    private readonly ArticlesServices _service;
    //    private readonly IMapper _mapper;
    //    public ArticlesController(MyDbContext _context)
    //    {
    //        _service = new ArticlesServices(_context);
    //        var config = new MapperConfiguration(cfg =>
    //        {
    //            cfg.AddProfile<ArticlesProfile>();
    //        });
    //        _mapper = config.CreateMapper();
    //    }
    //}

    public class ArticlesController : ControllerBase
    {

        private readonly ArticlesServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="_context"></param>
        public ArticlesController(MyDbContext _context)
        {
            _service = new ArticlesServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArticlesProfile>();
            });
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>La liste de tous les objets mappés au format choisi.</returns>
        public IEnumerable<ArticlesDTO> GetAllArticles()
        {
            var listObjets = _service.GetAllArticles();
            return _mapper.Map<IEnumerable<ArticlesDTO>>(listObjets);
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>Retourne l'objet voulu s'il existe, un objet vide sinon.</returns>
        public Article GetArticleById(int id)
        {
            var obj = _service.GetArticleById(id);
            if (obj != null)
            {
                return obj;
            }
            return new Article();
        }

        /// <summary>
        /// Créer un objet
        /// </summary>
        /// <param name="objetPasse"></param>
        public void CreateArticle(Article objetPasse)
        {
            Article obj = _mapper.Map<Article>(objetPasse);
            //on ajoute l'objet à la base de données
            _service.AddArticle(obj);
        }

        /// <summary>
        /// Mettre à jour un objet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retourne 0 si la modification s'est bien passée, -1 sinon.</returns>
        public int UpdateArticle(Article obj)
        {
            var objFromRepo = _service.GetArticleById(obj.IdArticle);
            if (objFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateArticle(objFromRepo);
            return 0;
        }

        /// <summary>
        /// Supprimer un objet
        /// </summary>
        /// <param name="id">ID de l'objet que l'on veut supprimer</param>
        /// <returns>Retourne 0 si la suppression s'est bien passée, -1 sinon.</returns>
        public int DeleteArticle(int id)
        {
            var objModelFromRepo = _service.GetArticleById(id);
            if (objModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteArticle(objModelFromRepo);
            return 0;
        }
    }
}
