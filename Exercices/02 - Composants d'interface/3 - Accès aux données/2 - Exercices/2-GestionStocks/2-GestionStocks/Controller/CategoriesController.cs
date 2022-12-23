using _2_GestionStocks.Data;
using _2_GestionStocks.Data.Profiles;
using _2_GestionStocks.Data.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Controller
{
    class CategoriesController
    {
        private readonly CategoryServices _service;
        private readonly IMapper _mapper;
        public CategoriesController(MyDbContext _context)
        {
            _service = new CategoryServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoryProfile>();
            });
            _mapper = config.CreateMapper();
        }
    }
}
