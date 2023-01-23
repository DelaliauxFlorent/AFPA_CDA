using AutoMapper;
using ECF.Data.Dtos;
using ECF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECF.Data.Profiles
{
    public class MusiciensProfiles : Profile
    {
        public MusiciensProfiles()
        {
            CreateMap<Musicien, MusiciensDTOOutAvecGroupe>().ForMember(c => c.NomDuGroupe, a => a.MapFrom(s => s.Groupe.NomDuGroupe));
            CreateMap<Musicien, MusiciensDTOOut>();
            CreateMap<MusiciensDTOIn, Musicien>();
        }
    }
}
