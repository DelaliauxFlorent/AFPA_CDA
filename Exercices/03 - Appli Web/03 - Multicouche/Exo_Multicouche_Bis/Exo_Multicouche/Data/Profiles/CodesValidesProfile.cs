using AutoMapper;
using Exo_Multicouche.Data.Dtos;
using Exo_Multicouche.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo_Multicouche.Data.Profiles
{
    public class CodesValidesProfile: Profile
    {
        public CodesValidesProfile()
        {
            CreateMap<CodesValide, CodesValideDTO>();
            CreateMap<CodesValideDTO, CodesValide>();
        }
    }
}
