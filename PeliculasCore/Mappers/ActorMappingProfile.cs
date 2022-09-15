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
    public class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<ActorDTO, Actor>().ReverseMap();
            CreateMap<ActorCreateDTO, Actor>().ForMember(x => x.Photo, options => options.Ignore());

        }
    }
}
