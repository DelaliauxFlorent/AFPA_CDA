using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Dtos
{
    public class CountryDTO
    {
        public CountryDTO()
        {
            Cities = new HashSet<CityDTO>();
        }

        public string NameCountry { get; set; }

        public virtual ICollection<CityDTO> Cities { get; set; }
    }
    public class CountryDTOName
    {
        public string NameCountry { get; set; }
    }
}
