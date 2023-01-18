using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Dtos
{
    public class CityDTO
    {

        public string NameCity { get; set; }
        public int IdCountry { get; set; }
        public string CountryName { get; set; }
    }

    public class CityDTONameOnly
    {
        public string NameCity { get; set; }
    }
    public class CityDTONameID
    {
        public int IdCity { get; set; }
        public string NameCity { get; set; }
    }
}
