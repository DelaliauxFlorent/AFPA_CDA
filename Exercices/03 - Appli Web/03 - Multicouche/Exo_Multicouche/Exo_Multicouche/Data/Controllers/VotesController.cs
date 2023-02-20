using AutoMapper;
using Exo_Multicouche.Data.Dtos;
using Exo_Multicouche.Data.Models;
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
    /// Classe des Controllers pour les Votes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {

        private readonly VotesServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper"></param>
        public VotesController(VotesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Récupérer la liste de tous les objets
        /// </summary>
        /// <returns>ActionResult=>OK + La liste de tous les objets mappés au format choisi.</returns>
        //GET api/Votes
        [HttpGet]
        public ActionResult<IEnumerable<VoteDTO>> GetAllVotes()
        {
            var listObjets = _service.GetAllVotes();
            return Ok(_mapper.Map<IEnumerable<VoteDTO>>(listObjets));
        }

        /// <summary>
        /// Récupérer un objet spécifique par son ID
        /// </summary>
        /// <param name="id">ID de l'objet voulu.</param>
        /// <returns>ActionResult=>OK + L'objet voulu s'il existe, ActionResult=>NotFound sinon.</returns>
        //GET api/Votes/{id}
        [HttpGet("{id}", Name = "GetVoteById")]
        public ActionResult<VoteDTO> GetVoteById(int id)
        {
            var obj = _service.GetVoteById(id);
            if (obj != null)
            {
                return Ok(_mapper.Map<VoteDTO>(obj));
            }
            return NotFound();
        }

        /// <summary>
        /// Créer un objet
        /// </summary>
        /// <param name="objetPasse"></param>
        /// <returns>Le chemin de FinById avec l'objet créé.</returns>
        //POST api/Votes
        [HttpPost]
        public ActionResult<VoteDTO> CreateVote(Vote objetPasse)
        {
            //on ajoute l'objet à la base de données
            _service.AddVote(objetPasse);
            //on retourne le chemin de FinById avec l'objet créé
            return CreatedAtRoute(nameof(GetVoteById), new { Id = objetPasse.IdVote}, objetPasse);
        }

    }
}
