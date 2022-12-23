using _2_GestionStocks.Data.Dtos;
using _2_GestionStocks.Models.DbModels;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Data.Profiles
{
    class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoriesDTOIn>();
            CreateMap<CategoriesDTOIn, Category>();
            CreateMap<Category, CategoriesDTOAvecLibelleTypeProduit>();
            CreateMap<CategoriesDTOAvecLibelleTypeProduit, Category>();

            /******** Différence avec une API  ********/
            CreateMap<Category, CategoriesDTOAvecLibelleTypeProduit>().ForMember(d => d.LibelleTypeProduit, o => o.MapFrom(s => s.IdTypeProduitNavigation.LibelleTypeProduit));
        }
    }
}
