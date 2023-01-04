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

        public virtual CountryDTOName Country { get; set; }
    }
}
