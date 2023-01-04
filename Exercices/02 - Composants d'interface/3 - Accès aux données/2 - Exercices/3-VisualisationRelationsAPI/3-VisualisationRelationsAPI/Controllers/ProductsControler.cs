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
    public class ProductsController : ControllerBase
    {
        private readonly ProductsServices _service;
        private readonly IMapper _mapper;

        public ProductsController(ProductsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var listProducts = _service.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(listProducts));
        }

        //GET api/Products/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            var commandItem = _service.GetProductById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ProductDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/Products
        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct(Product Product)
        {
            //on ajoute l'objet à la base de données
            _service.AddProduct(Product);
            //on retourne le chemin de FindById avec l'objet créé
            return CreatedAtRoute(nameof(GetProductById), new { Id = Product.IdProduct }, Product);
        }

        //PUT api/Products/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductDTO Product)
        {
            var ProductFromRepo = _service.GetProductById(id);
            if (ProductFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(Product, ProductFromRepo);
            _service.UpdateProduct(ProductFromRepo);
            return NoContent();
        }

        //PATCH api/Products/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialProductUpdate(int id, JsonPatchDocument<Product> patchDoc)
        {
            var ProductFromRepo = _service.GetProductById(id);
            if (ProductFromRepo == null)
            {
                return NotFound();
            }

            var ProductToPatch = _mapper.Map<Product>(ProductFromRepo);
            patchDoc.ApplyTo(ProductToPatch, ModelState);

            if (!TryValidateModel(ProductToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ProductToPatch, ProductFromRepo);

            _service.UpdateProduct(ProductFromRepo);

            return NoContent();
        }

        //DELETE api/Products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var ProductModelFromRepo = _service.GetProductById(id);
            if (ProductModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteProduct(ProductModelFromRepo);
            return NoContent();
        }

    }

}
