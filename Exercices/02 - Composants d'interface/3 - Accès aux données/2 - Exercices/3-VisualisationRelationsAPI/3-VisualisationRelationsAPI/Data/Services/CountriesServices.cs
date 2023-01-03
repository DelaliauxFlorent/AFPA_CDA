using _3_VisualisationRelationsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Services
{
    public class CountriesServices
    {

        private readonly MyDbContext _context;

        public CountriesServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddCountrie(Country a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Countries.Add(a);
            _context.SaveChanges();
        }

        public void DeleteCountrie(Country a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            _context.Countries.Remove(a);
            _context.SaveChanges();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountrieById(int id)
        {
            return _context.Countries.FirstOrDefault(a => a.IdCountry== id);
        }

        public void UpdateCountrie(Country a)
        {
            _context.SaveChanges();
        }

    }
}
