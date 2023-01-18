﻿using AutoMapper;
using PizzeriaPadanana.Data.DTOs;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Profiles
{
    public class ComptesProfile : Profile
    {
        protected ComptesProfile()
        {
            CreateMap<Compte, CompteDTO>();
            CreateMap<CompteDTO, Compte>();
            CreateMap<Compte, CompteDTO_Simple>();
            CreateMap<CompteDTO_Simple, Compte>();
            CreateMap<Compte, CompteDTO_Connexion>();
            CreateMap<CompteDTO_Connexion, Compte>();
            CreateMap<Compte, CompteDTO_Simple>();
            CreateMap<CompteDTO_Simple, Compte>();
            CreateMap<Compte, CompteDTO_Creation>().ForMember(c2=>c2.Adresse, o=>o.MapFrom(c=>c.Adresses));
            CreateMap<CompteDTO_Creation, Compte>();
        }
    }
}
