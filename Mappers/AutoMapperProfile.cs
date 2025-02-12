using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NzWalks.Models.Domain;
using NzWalks.Models.DTOs;

namespace NzWalks.Mappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region,AddNewRegionDto>().ReverseMap();
            CreateMap<Region,PutRegionDto>().ReverseMap();
            CreateMap<Walks,AddWalkDto>().ReverseMap();
            CreateMap<Walks,WalkDto>().ReverseMap();
        }
    }
}