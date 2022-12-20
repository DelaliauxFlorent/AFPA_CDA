using _3_CreerAPI.Data.Dtos;
using _3_CreerAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_CreerAPI.Data.Profiles
{
    public class PersonnesProfile:Profile
    {
        public PersonnesProfile()
        {
            CreateMap<Personne, PersonnesDTO>();
            CreateMap<PersonnesDTO, Personne>();
        }
    }
}
