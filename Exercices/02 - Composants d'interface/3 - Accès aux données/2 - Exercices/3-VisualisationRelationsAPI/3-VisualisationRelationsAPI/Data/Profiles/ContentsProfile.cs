using _3_VisualisationRelationsAPI.Data.Dtos;
using _3_VisualisationRelationsAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Profiles
{
    public class ContentsProfile : Profile
    {
        public ContentsProfile()
        {
            CreateMap<Content, ContentDTO>();
            CreateMap<ContentDTO, Content>();
        }
    }
}
