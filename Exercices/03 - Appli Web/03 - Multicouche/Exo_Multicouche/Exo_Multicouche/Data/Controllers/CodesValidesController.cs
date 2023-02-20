using AutoMapper;
using Exo_Multicouche.Data.Dtos;
using Exo_Multicouche.Data.Models;
using Exo_Multicouche.Data.Profiles;
using Exo_Multicouche.Data.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo_Multicouche.Data.Controllers
{

    // API ver. Controller

    /// <summary>
    /// Classe des Controllers pour les CodesValides
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CodesValidesController : ControllerBase
    {

        private readonly CodesValidesServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper"></param>
        public CodesValidesController(CodesValidesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>ActionResult=>OK + La liste de tous les objets mappés au format choisi.</returns>
        //GET api/CodesValides
        [HttpGet]
        public ActionResult<IEnumerable<CodesValideDTO>> GetAllCodesValides()
        {
            var listObjets = _service.GetAllCodesValides();
            return Ok(_mapper.Map<IEnumerable<CodesValideDTO>>(listObjets));
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>ActionResult=>OK + L'objet voulu s'il existe, ActionResult=>NotFound sinon.</returns>
        //GET api/CodesValides/{id}
        [HttpGet("{id}", Name = "GetCodesValideById")]
        public ActionResult<CodesValideDTO> GetCodesValideById(int id)
        {
            var obj = _service.GetCodesValideById(id);
            if (obj != null)
            {
                return Ok(_mapper.Map<CodesValideDTO>(obj));
            }
            return NotFound();
        }

        /// <summary>
        /// Mettre à jour un objet
        /// </summary>
        /// <param name="id">ID de l'objet à modifier</param>
        /// <param name="obj">Objet modifié</param>
        /// <returns>Retourne l'ActionResult indiquant si la modification s'est bien passée ou non.</returns>
        //PUT api/CodesValides/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCodesValide(int id, CodesValide obj)
        {
            var objFromRepo = _service.GetCodesValideById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateCodesValide(objFromRepo);
            return NoContent();
        }

    }

}
