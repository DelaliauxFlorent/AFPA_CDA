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
            CreateMap<Content, ContentDTOForCommands>().ForMember(c=>c.NameProduct, o=>o.MapFrom(s=>s.Product.NameProduct)).ForMember(c=>c.PricePoduct, o=>o.MapFrom(s=>s.Product.PriceProduct));
            CreateMap<ContentDTOForCommands, Content>();
            CreateMap<Content, ContentDTOForProduits>().ForMember(c=>c.AddressDeliv, o=>o.MapFrom(s=>s.Command.DeliveryAddressCommand));
            CreateMap<ContentDTOForProduits, Content>();
        }
    }
}
