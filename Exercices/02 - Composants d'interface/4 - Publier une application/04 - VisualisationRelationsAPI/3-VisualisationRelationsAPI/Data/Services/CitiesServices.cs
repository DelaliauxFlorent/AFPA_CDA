using _3_VisualisationRelationsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Services
{
    public class CitiesServices
    {

        private readonly MyDbContext _context;

        public CitiesServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddCity(City a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Cities.Add(a);
            _context.SaveChanges();
        }

        public void DeleteCity(City a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Cities.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities.Include("Country").ToList();
        }

        public City GetCityById(int id)
        {
            return _context.Cities.Include("Country").FirstOrDefault(a => a.IdCity == id);
        }

        public void UpdateCity(City a)
        {
            _context.SaveChanges();
        }

    }
}