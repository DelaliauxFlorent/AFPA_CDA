using _2_GestionStocks.Data.Dtos;
using _2_GestionStocks.Models.DbModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Data.Profiles
{
    public class ArticlesProfile:Profile
    {
        public ArticlesProfile()
        {
            // on réalise le mapping entre les objets et les DTOs
            CreateMap<Article, ArticlesDTO>();
            CreateMap<ArticlesDTO, Article>();
            CreateMap<Article, ArticlesDTOIn>();
            CreateMap<ArticlesDTOIn, Article>();
            CreateMap<Article, ArticlesDTOAvecLibelleCategorie>();
            CreateMap<ArticlesDTOAvecLibelleCategorie, Article>();

        }
    }
}
