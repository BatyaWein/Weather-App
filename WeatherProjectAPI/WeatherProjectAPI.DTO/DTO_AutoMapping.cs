using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.DTO
{
    public class DTO_AutoMapping : Profile
    {
        public DTO_AutoMapping()
        {
            CreateMap<User, DTO_User>();
            CreateMap<DTO_User, User>();
            CreateMap<Favorite, DTO_Favorite>();
            CreateMap<DTO_Favorite, Favorite>();
        }
    }
}
