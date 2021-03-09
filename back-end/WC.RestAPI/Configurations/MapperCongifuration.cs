using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Model.Entity;
using WC.Model.DTO;
using WC.RestAPI.Model.Login.Request;

namespace WC.RestAPI.Configurations
{
    public class MapperCongifuration : Profile
    {
        public MapperCongifuration()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RegisterUserRequest, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
