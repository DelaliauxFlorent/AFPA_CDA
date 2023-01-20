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
    /// <summary>
    /// Classe de Profile pour les Types de Pizzas
    /// </summary>
    class TypepizzasProfile : Profile
    {
        /// <summary>
        /// Liste des mappings
        /// </summary>
        public TypepizzasProfile()
        {
            CreateMap<Typepizza, TypepizzaDTO>();
            CreateMap<TypepizzaDTO, Typepizza>();
        }
    }
}
