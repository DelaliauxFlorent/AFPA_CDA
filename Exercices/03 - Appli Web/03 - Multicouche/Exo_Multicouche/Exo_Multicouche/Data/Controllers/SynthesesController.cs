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
    /// Classe des Controllers pour les Syntheses
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SynthesesController : ControllerBase
    {

        private readonly SynthesesServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper"></param>
        public SynthesesController(SynthesesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>ActionResult=>OK + La liste de tous les objets mappés au format choisi.</returns>
        //GET api/Syntheses
        [HttpGet]
        public ActionResult<IEnumerable<SyntheseDTO>> GetAllSyntheses()
        {
            var listObjets = _service.GetAllSyntheses();
            return Ok(_mapper.Map<IEnumerable<SyntheseDTO>>(listObjets));
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>ActionResult=>OK + L'objet voulu s'il existe, ActionResult=>NotFound sinon.</returns>
        //GET api/Syntheses/{id}
        [HttpGet("{id}", Name = "GetSyntheseById")]
        public ActionResult<SyntheseDTO> GetSyntheseById(int id)
        {
            var obj = _service.GetSyntheseById(id);
            if (obj != null)
            {
                return Ok(_mapper.Map<SyntheseDTO>(obj));
            }
            return NotFound();
        }

    }

}
