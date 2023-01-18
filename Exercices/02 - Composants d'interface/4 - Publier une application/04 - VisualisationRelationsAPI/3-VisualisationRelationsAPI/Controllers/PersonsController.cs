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
    public class PersonsController:ControllerBase
    {
        private readonly PersonsServices _service;
        private readonly IMapper _mapper;

        public PersonsController(PersonsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/persons
        [HttpGet]
        public ActionResult<IEnumerable<PersonDTO>> GetAllPersons()
        {
            var listPersons = _service.GetAllPersons();
            return Ok(_mapper.Map<IEnumerable<PersonDTO>>(listPersons));
        }

        //GET api/persons/{id}
        [HttpGet("{id}", Name ="GetPersonById")]
        public ActionResult<PersonDTO> GetPersonById(int id)
        {
            var commandItem = _service.GetPersonById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<PersonDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/persons
        [HttpPost]
        public ActionResult<PersonDTO> CreatePerson(Person person)
        {
            //on ajoute l'objet à la base de données
            _service.AddPerson(person);
            //on retourne le chemin de FindById avec l'objet créé
            return CreatedAtRoute(nameof(GetPersonById), new { Id = person.IdPerson }, person);
        }

        //PUT api/persons/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePerson(int id, PersonDTO person)
        {
            var personFromRepo = _service.GetPersonById(id);
            if (personFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(person, personFromRepo);
            _service.UpdatePerson(personFromRepo);
            return NoContent();
        }

        //PATCH api/persons/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPersonUpdate(int id, JsonPatchDocument<Person> patchDoc)
        {
            var personFromRepo = _service.GetPersonById(id);
            if (personFromRepo == null)
            {
                return NotFound();
            }

            var personToPatch = _mapper.Map<Person>(personFromRepo);
            patchDoc.ApplyTo(personToPatch, ModelState);

            if (!TryValidateModel(personToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(personToPatch, personFromRepo);

            _service.UpdatePerson(personFromRepo);

            return NoContent();
        }

        //DELETE api/persons/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var personModelFromRepo = _service.GetPersonById(id);
            if (personModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeletePerson(personModelFromRepo);
            return NoContent();
        }

    }
}
