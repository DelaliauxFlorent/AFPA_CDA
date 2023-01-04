using _3_VisualisationRelationsAPI.Data.Dtos;
using _3_VisualisationRelationsAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Profiles
{
    public class CitiesProfile : Profile
    {
        public CitiesProfile()
        {
            CreateMap<City, CityDTO>().ForMember(c=>c.CountryName, o=>o.MapFrom(s=>s.Country.NameCountry));
            CreateMap<CityDTO, City>();
            CreateMap<City, CityDTONameOnly>();
            CreateMap<CityDTONameOnly, City>();
        }
    }
}
