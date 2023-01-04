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
    public class CountriesController : ControllerBase
    {
        private readonly CountriesServices _service;
        private readonly IMapper _mapper;

        public CountriesController(CountriesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Countries
        [HttpGet]
        public ActionResult<IEnumerable<CountryDTO>> GetAllCountries()
        {
            var listCountries = _service.GetAllCountries();
            return Ok(_mapper.Map<IEnumerable<CountryDTO>>(listCountries));
        }

        //GET api/Countries/{id}
        [HttpGet("{id}", Name = "GetCountryById")]
        public ActionResult<CountryDTO> GetCountryById(int id)
        {
            var commandItem = _service.GetCountryById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CountryDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/Countries
        [HttpPost]
        public ActionResult<CountryDTO> CreateCountry(Country Country)
        {
            //on ajoute l'objet à la base de données
            _service.AddCountry(Country);
            //on retourne le chemin de FindById avec l'objet créé
            return CreatedAtRoute(nameof(GetCountryById), new { Id = Country.IdCountry }, Country);
        }

        //PUT api/Countries/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCountry(int id, CountryDTO Country)
        {
            var CountryFromRepo = _service.GetCountryById(id);
            if (CountryFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(Country, CountryFromRepo);
            _service.UpdateCountry(CountryFromRepo);
            return NoContent();
        }

        //PATCH api/Countries/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCountryUpdate(int id, JsonPatchDocument<Country> patchDoc)
        {
            var CountryFromRepo = _service.GetCountryById(id);
            if (CountryFromRepo == null)
            {
                return NotFound();
            }

            var CountryToPatch = _mapper.Map<Country>(CountryFromRepo);
            patchDoc.ApplyTo(CountryToPatch, ModelState);

            if (!TryValidateModel(CountryToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(CountryToPatch, CountryFromRepo);

            _service.UpdateCountry(CountryFromRepo);

            return NoContent();
        }

        //DELETE api/Countries/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCountry(int id)
        {
            var CountryModelFromRepo = _service.GetCountryById(id);
            if (CountryModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteCountry(CountryModelFromRepo);
            return NoContent();
        }

    }

}
