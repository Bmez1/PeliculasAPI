using AutoMapper;
using PeliculasCore.DTOs;
using PeliculasCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Mappers
{
    public class GenderMappingProfile : Profile
    {
        public GenderMappingProfile()
        {
            CreateMap<GenderCreateDTO, Gender>().ReverseMap();
            CreateMap<GenderDTO, Gender>().ReverseMap();
        }
    }
}
