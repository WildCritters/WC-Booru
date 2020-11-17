using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Model.Security;

namespace WC.RestAPI.Configurations
{
    public class MapperCongifuration : Profile
    {
        public MapperCongifuration()
        {
            CreateMap<User, Model.DTO.User>().ReverseMap();
            CreateMap<Role, Model.DTO.Role>().ReverseMap();
        }
    }
}
