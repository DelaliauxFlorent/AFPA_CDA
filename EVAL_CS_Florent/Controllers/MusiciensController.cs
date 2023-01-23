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
    /// Classe des Controllers pour les Musiciens
    /// </summary>
    public class MusiciensController : ControllerBase
    {

        private readonly MusiciensServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="_context"></param>
        public MusiciensController(EcfContext _context)
        {
            _service = new MusiciensServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MusiciensProfiles>();
                cfg.AddProfile<GroupesProfiles>();
            });
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>La liste de tous les objets mappés au format choisi.</returns>
        public IEnumerable<MusiciensDTOOut> GetAllMusiciens()
        {
            var listObjets = _service.GetAllMusiciens();
            return _mapper.Map<IEnumerable<MusiciensDTOOut>>(listObjets);
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>La liste de tous les objets mappés au format choisi.</returns>
        public IEnumerable<MusiciensDTOOutAvecGroupe> GetAllMusiciensAvecGroupe()
        {
            var listObjets = _service.GetAllMusiciens();
            return _mapper.Map<IEnumerable<MusiciensDTOOutAvecGroupe>>(listObjets);
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>Retourne l'objet voulu s'il existe, un objet vide sinon.</returns>
        public Musicien GetMusicienById(int id)
        {
            var obj = _service.GetMusicienById(id);
            if (obj != null)
            {
                return obj;
            }
            return new Musicien();
        }

        /// <summary>
        /// Créer un objet
        /// </summary>
        /// <param name="objetPasse"></param>
        public void CreateMusicien(MusiciensDTOIn objetPasse)
        {
            Musicien obj = _mapper.Map<Musicien>(objetPasse);
            //on ajoute l'objet à la base de données
            _service.AddMusicien(obj);
        }

        /// <summary>
        /// Mettre à jour un objet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retourne 0 si la modification s'est bien passée, -1 sinon.</returns>
        public int UpdateMusicien(int id, MusiciensDTOIn obj)
        {
            var objFromRepo = _service.GetMusicienById(id);
            if (objFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateMusicien(objFromRepo);
            return 0;
        }

        /// <summary>
        /// Supprimer un objet
        /// </summary>
        /// <param name="id">ID de l'objet que l'on veut supprimer</param>
        /// <returns>Retourne 0 si la suppression s'est bien passée, -1 sinon.</returns>
        public int DeleteMusicien(int id)
        {
            var objModelFromRepo = _service.GetMusicienById(id);
            if (objModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteMusicien(objModelFromRepo);
            return 0;
        }
    }
}
