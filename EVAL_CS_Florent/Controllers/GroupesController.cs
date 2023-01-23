using AutoMapper;
using ECF.Data;
using ECF.Data.Dtos;
using ECF.Data.Models;
using ECF.Data.Profiles;
using ECF.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECF.Controllers
{

    // Non-API ver. Controller

    /// <summary>
    /// Classe des Controllers pour les Groupes
    /// </summary>
    public class GroupesController : ControllerBase
    {

        private readonly GroupesServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="_context"></param>
        public GroupesController(EcfContext _context)
        {
            _service = new GroupesServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GroupesProfiles>();
                cfg.AddProfile<MusiciensProfiles>();
            });
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>La liste de tous les objets mappés au format choisi.</returns>
        public IEnumerable<GroupesDTOOut> GetAllGroupes()
        {
            var listObjets = _service.GetAllGroupes();
            return _mapper.Map<IEnumerable<GroupesDTOOut>>(listObjets);
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>La liste de tous les objets mappés au format choisi.</returns>
        public IEnumerable<GroupesDTOOutAvecMusiciens> GetAllGroupesAvecMusiciens()
        {
            var listObjets = _service.GetAllGroupes();
            return _mapper.Map<IEnumerable<GroupesDTOOutAvecMusiciens>>(listObjets);
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>Retourne l'objet voulu s'il existe, un objet vide sinon.</returns>
        public Groupe GetGroupeById(int id)
        {
            var obj = _service.GetGroupeById(id);
            if (obj != null)
            {
                return obj;
            }
            return new Groupe();
        }

        /// <summary>
        /// Créer un objet
        /// </summary>
        /// <param name="objetPasse"></param>
        public void CreateGroupe(GroupesDTOIn objetPasse)
        {
            Groupe obj = _mapper.Map<Groupe>(objetPasse);
            //on ajoute l'objet à la base de données
            _service.AddGroupe(obj);
        }

        /// <summary>
        /// Mettre à jour un objet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retourne 0 si la modification s'est bien passée, -1 sinon.</returns>
        public int UpdateGroupe(int id, GroupesDTOIn obj)
        {
            var objFromRepo = _service.GetGroupeById(id);
            if (objFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateGroupe(objFromRepo);
            return 0;
        }

        /// <summary>
        /// Supprimer un objet
        /// </summary>
        /// <param name="id">ID de l'objet que l'on veut supprimer</param>
        /// <returns>Retourne 0 si la suppression s'est bien passée, -1 sinon.</returns>
        public int DeleteGroupe(int id)
        {
            var objModelFromRepo = _service.GetGroupeById(id);
            if (objModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteGroupe(objModelFromRepo);
            return 0;
        }
    }


}
