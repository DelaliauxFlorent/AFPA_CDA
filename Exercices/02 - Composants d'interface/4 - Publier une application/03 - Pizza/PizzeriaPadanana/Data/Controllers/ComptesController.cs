using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzeriaPadanana.Data.Services;
using PizzeriaPadanana.Data.POCOs;
using PizzeriaPadanana.Data.DTOs;
using PizzeriaPadanana.Data.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace PizzeriaPadanana.Data.Controllers
{
    class ComptesController : ControllerBase
    {

        private readonly ComptesServices _service;
        private readonly IMapper _mapper;

        public ComptesController(ComptesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompteDTO_Simple>> GetAllComptes()
        {
            var listeComptes = _service.GetAllComptes();
            return Ok(_mapper.Map<IEnumerable<CompteDTO_Simple>>(listeComptes));
        }

        [HttpGet("{id}", Name = "GetCompteById")]
        public ActionResult<CompteDTO_Simple> GetCompteById(int id)
        {
            var vItem = _service.GetCompteById(id);
            if (vItem != null)
            {
                return Ok(_mapper.Map<CompteDTO_Simple>(vItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CompteDTO_Simple> CreateCompte(Compte v)
        {
            _service.AddCompte(v);
            return CreatedAtRoute(nameof(GetCompteById), new { Id = v.IdCompte }, v);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCompte(int id, Compte v)
        {
            var vFromRepo = _service.GetCompteById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(v, vFromRepo);
            _service.UpdateCompte(vFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCompteUpdate(int id, JsonPatchDocument<Compte> patchDoc)
        {
            var vFromRepo = _service.GetCompteById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }

            var vToPatch = _mapper.Map<Compte>(vFromRepo);
            patchDoc.ApplyTo(vToPatch, ModelState);

            if (!TryValidateModel(vToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(vToPatch, vFromRepo);
            _service.UpdateCompte(vFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCompte(int id)
        {
            var vModelFromRepo = _service.GetCompteById(id);
            if (vModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteCompte(vModelFromRepo);
            return NoContent();
        }
    }
}
