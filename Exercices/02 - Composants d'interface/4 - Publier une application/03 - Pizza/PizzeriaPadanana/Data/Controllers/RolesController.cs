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
    /// <summary>
    /// Classe des controllers pour les Rôles
    /// </summary>
    class RolesController : ControllerBase
    {

        private readonly RolesServices _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper"></param>
        public RolesController(RolesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Listing de tous les Rôles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<RoleDTO_Simple>> GetAllRoles()
        {
            var listeRoles = _service.GetAllRoles();
            return Ok(_mapper.Map<IEnumerable<RoleDTO_Simple>>(listeRoles));
        }

        /// <summary>
        /// Récupération d'un rôle précis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetRoleById")]
        public ActionResult<RoleDTO_Simple> GetRoleById(int id)
        {
            var vItem = _service.GetRoleById(id);
            if (vItem != null)
            {
                return Ok(_mapper.Map<RoleDTO_Simple>(vItem));
            }
            return NotFound();
        }

        /// <summary>
        /// Créer un rôle
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RoleDTO_Simple> CreateRole(Role v)
        {
            _service.AddRole(v);
            return CreatedAtRoute(nameof(GetRoleById), new { Id = v.IdRole }, v);
        }

        /// <summary>
        /// Mise à jour d'un rôle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateRole(int id, Role v)
        {
            var vFromRepo = _service.GetRoleById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(v, vFromRepo);
            _service.UpdateRole(vFromRepo);
            return NoContent();
        }

        /// <summary>
        /// Mise à jour partielle d'un rôle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult PartialRoleUpdate(int id, JsonPatchDocument<Role> patchDoc)
        {
            var vFromRepo = _service.GetRoleById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }

            var vToPatch = _mapper.Map<Role>(vFromRepo);
            patchDoc.ApplyTo(vToPatch, ModelState);

            if (!TryValidateModel(vToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(vToPatch, vFromRepo);
            _service.UpdateRole(vFromRepo);

            return NoContent();
        }

        /// <summary>
        /// Suppression d'un rôle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteRole(int id)
        {
            var vModelFromRepo = _service.GetRoleById(id);
            if (vModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteRole(vModelFromRepo);
            return NoContent();
        }
    }
}
