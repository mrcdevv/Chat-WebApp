using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatWebApp.DTOs;
using ChatWebApp.Models;

namespace ChatWebApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserDto>();

            CreateMap<User, UserInfoDto>()
                .ForMember(x => x.UserId, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.UserName, y => y.MapFrom(src => src.UserName))
                .ForMember(x => x.UserEmail, y => y.MapFrom(src => src.Email))
                .ReverseMap();
        }



    }
}