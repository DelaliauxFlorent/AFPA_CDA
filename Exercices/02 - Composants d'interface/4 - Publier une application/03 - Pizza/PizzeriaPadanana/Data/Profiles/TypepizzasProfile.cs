using AutoMapper;
using PizzeriaPadanana.Data.DTOs;
using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.Profiles
{
    class TypepizzasProfile : Profile
    {
        public TypepizzasProfile()
        {
            CreateMap<Typepizza, TypepizzaDTO>();
            CreateMap<TypepizzaDTO, Typepizza>();
        }
    }
}
