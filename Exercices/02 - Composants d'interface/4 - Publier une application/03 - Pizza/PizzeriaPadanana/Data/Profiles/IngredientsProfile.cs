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
    /// Classe de Profile pour les Ingrédients
    /// </summary>
    class IngredientsProfile :Profile
    {
        /// <summary>
        /// Liste des mappings
        /// </summary>
        public IngredientsProfile()
        {
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Ingredient, IngredientDTOAvecType>().ForMember(c=>c.NomTypeIngredient, o=>o.MapFrom(s=>s.IdTypeIngredientNavigation.NomTypeIngredient)).ForMember(c=>c.Prix, o=>o.MapFrom(s=>s.IdTypeIngredientNavigation.PrixTypeIngredient));
            CreateMap<IngredientDTOAvecType, Ingredient>();
        }
    }
}
