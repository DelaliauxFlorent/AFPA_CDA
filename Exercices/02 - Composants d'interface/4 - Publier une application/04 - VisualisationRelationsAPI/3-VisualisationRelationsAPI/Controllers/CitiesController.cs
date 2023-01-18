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
    public class CitiesController : ControllerBase
    {
        private readonly CitiesServices _service;
        private readonly IMapper _mapper;

        public CitiesController(CitiesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Cities
        [HttpGet]
        public ActionResult<IEnumerable<CityDTO>> GetAllCities()
        {
            var listCities = _service.GetAllCities();
            return Ok(_mapper.Map<IEnumerable<CityDTO>>(listCities));
        }

        //GET api/Cities/{id}
        [HttpGet("{id}", Name = "GetCityById")]
        public ActionResult<CityDTO> GetCityById(int id)
        {
            var commandItem = _service.GetCityById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CityDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/Cities
        [HttpPost]
        public ActionResult<CityDTO> CreateCity(City City)
        {
            //on ajoute l'objet à la base de données
            _service.AddCity(City);
            //on retourne le chemin de FindById avec l'objet créé
            return CreatedAtRoute(nameof(GetCityById), new { Id = City.IdCity }, City);
        }

        //PUT api/Cities/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCity(int id, CityDTO City)
        {
            var CityFromRepo = _service.GetCityById(id);
            if (CityFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(City, CityFromRepo);
            _service.UpdateCity(CityFromRepo);
            return NoContent();
        }

        //PATCH api/Cities/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCityUpdate(int id, JsonPatchDocument<City> patchDoc)
        {
            var CityFromRepo = _service.GetCityById(id);
            if (CityFromRepo == null)
            {
                return NotFound();
            }

            var CityToPatch = _mapper.Map<City>(CityFromRepo);
            patchDoc.ApplyTo(CityToPatch, ModelState);

            if (!TryValidateModel(CityToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(CityToPatch, CityFromRepo);

            _service.UpdateCity(CityFromRepo);

            return NoContent();
        }

        //DELETE api/Cities/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCity(int id)
        {
            var CityModelFromRepo = _service.GetCityById(id);
            if (CityModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteCity(CityModelFromRepo);
            return NoContent();
        }

    }

}
