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
    public class ContentsController : ControllerBase
    {
        private readonly ContentsServices _service;
        private readonly IMapper _mapper;

        public ContentsController(ContentsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Contents
        [HttpGet]
        public ActionResult<IEnumerable<ContentDTO>> GetAllContents()
        {
            var listContents = _service.GetAllContents();
            return Ok(_mapper.Map<IEnumerable<ContentDTO>>(listContents));
        }

    }


}
