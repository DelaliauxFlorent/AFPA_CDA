using System;
using System.Collections.Generic;

#nullable disable

namespace _3_VisualisationRelationsAPI.Models
{
    public partial class City
    {
        public int IdCity { get; set; }
        public string NameCity { get; set; }
        public int IdCountry { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
    }
}
