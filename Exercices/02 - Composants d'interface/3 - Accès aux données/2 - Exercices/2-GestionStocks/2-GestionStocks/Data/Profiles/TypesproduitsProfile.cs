﻿using AutoMapper;
using _2_GestionStocks.Data.Dtos;
using _2_GestionStocks.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GestionStocks.Data.Profiles
{
    class TypesproduitsProfile:Profile
    {
        public TypeproduitsProfile()
        {
            CreateMap<Typesproduit>
        }

    }
}
