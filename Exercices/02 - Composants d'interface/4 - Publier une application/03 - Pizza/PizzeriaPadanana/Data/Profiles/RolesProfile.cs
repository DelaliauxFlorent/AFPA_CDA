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
    class RolesProfile : Profile
    {
        protected RolesProfile()
        {
            CreateMap<Role, RoleDTO>().ForMember(r2=>r2.Compte, op=>op.MapFrom(r=>r.Comptes));
            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO_Simple>();
            CreateMap<RoleDTO_Simple, Role>();
        }
    }
}
