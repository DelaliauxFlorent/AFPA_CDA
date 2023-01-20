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
    /// Classe de Profile pour les Types d'Ingrédients
    /// </summary>
    class TypeingredientsProfile :Profile
    {
        /// <summary>
        /// Liste des mappings
        /// </summary>
        public TypeingredientsProfile()
        {
            CreateMap<Typeingredient, TypeingredientDTO>();
            CreateMap<TypeingredientDTO, Typeingredient>();
        }
    }
}
