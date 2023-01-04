using _3_VisualisationRelationsAPI.Data.Dtos;
using _3_VisualisationRelationsAPI.Data.Services;
using _3_VisualisationRelationsAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandsServices _service;
        private readonly IMapper _mapper;

        public CommandsController(CommandsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandDTO>> GetAllCommands()
        {
            var listCommands = _service.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandDTO>>(listCommands));
        }

        //GET api/Commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandDTO> GetCommandById(int id)
        {
            var commandItem = _service.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/Commands
        [HttpPost]
        public ActionResult<CommandDTO> CreateCommand(Command Command)
        {
            //on ajoute l'objet à la base de données
            _service.AddCommand(Command);
            //on retourne le chemin de FindById avec l'objet créé
            return CreatedAtRoute(nameof(GetCommandById), new { Id = Command.IdCommand }, Command);
        }

        //PUT api/Commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandDTO Command)
        {
            var CommandFromRepo = _service.GetCommandById(id);
            if (CommandFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(Command, CommandFromRepo);
            _service.UpdateCommand(CommandFromRepo);
            return NoContent();
        }

        //PATCH api/Commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<Command> patchDoc)
        {
            var CommandFromRepo = _service.GetCommandById(id);
            if (CommandFromRepo == null)
            {
                return NotFound();
            }

            var CommandToPatch = _mapper.Map<Command>(CommandFromRepo);
            patchDoc.ApplyTo(CommandToPatch, ModelState);

            if (!TryValidateModel(CommandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(CommandToPatch, CommandFromRepo);

            _service.UpdateCommand(CommandFromRepo);

            return NoContent();
        }

        //DELETE api/Commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var CommandModelFromRepo = _service.GetCommandById(id);
            if (CommandModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteCommand(CommandModelFromRepo);
            return NoContent();
        }

    }

}
