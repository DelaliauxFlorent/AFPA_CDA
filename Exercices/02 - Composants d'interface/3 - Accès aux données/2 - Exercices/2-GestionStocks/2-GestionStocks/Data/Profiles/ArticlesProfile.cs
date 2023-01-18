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

            /******** Différence avec une API  ********/
            // pour le DTO ArticlesDTOAvecLibelleCategorie, on a mis l'objet à plat
            // C'est à dire que le libellé catégorie n'est pas un attribut de l'objet categorie à l'intérieur de l'objet Article
            // on a crée un attribut LibelleCategorie à l'intérieur de Article (directement)
            CreateMap<Article, ArticlesDTOAvecLibelleCategorie>().ForMember(d => d.LibelleCategorie, o => o.MapFrom(s => s.Category.LibelleCategorie));
        }
    }
}
