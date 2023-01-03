using System;
using System.Collections.Generic;

#nullable disable

namespace _3_VisualisationRelationsAPI.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int IdCountry { get; set; }
        public string NameCountry { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
