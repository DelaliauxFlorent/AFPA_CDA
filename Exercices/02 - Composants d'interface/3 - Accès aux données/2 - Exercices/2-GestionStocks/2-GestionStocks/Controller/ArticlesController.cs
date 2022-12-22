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
    class ArticlesController
    {
        private readonly ArticlesServices _service;
        private readonly IMapper _mapper;
        public ArticlesController(MyDbContext _context)
        {
            _service = new ArticlesServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArticlesProfile>();
            });
            _mapper = config.CreateMapper();
        }
    }
}
