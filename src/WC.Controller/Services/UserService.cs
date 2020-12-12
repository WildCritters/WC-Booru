using System;
using System.Collections.Generic;
using System.Linq;
using WC.Context.Configurations;
using WC.Controller.Repositories;
using WC.Controller.Repositories.Contract;
using WC.Model.Services.Contract;
using WC.Model.Entity;
using WC.Model.DTO;
using AutoMapper;

namespace WC.Model.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, 
            IRoleRepository roleRepository, 
            IMapper mapper)
        {
            this._userRepository = repository;
            this._roleRepository = roleRepository;
            this._mapper = mapper;
        }

        public bool ExistUsername(string username)
        {
            return this._userRepository.GetUserByUsername(username) != null;
        }

        public UserDto GetUser(int userId)
        {
            return _mapper.Map<UserDto>(this._userRepository.GetUserById(userId));
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDto>>(this._userRepository.GetUsers());
        }

        public UserDto Login(string username, string password)
        {
            return _mapper.Map<UserDto>(this._userRepository.Login(username, password));
        }

        public UserDto RegisterUser(UserDto userDto, string password)
        {
            userDto.Active = false;
            userDto.ActivationCode = Guid.NewGuid();
            userDto.DateOfCreation = DateTimeOffset.Now;
            userDto.RoleId = this._roleRepository.GetRoleByName("User").Id;
            var user = this._userRepository.RegisterUser(_mapper.Map<User>(userDto), password);
            return _mapper.Map<UserDto>(user);
        }
    }
}