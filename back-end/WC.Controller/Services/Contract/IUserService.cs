using System.Collections.Generic;
using WC.Model.DTO;
using WC.Model.Entity;

namespace WC.Model.Services.Contract
{
    public interface IUserService
    {
        public bool ExistUsername(string username);
        UserDto GetUser(long userId);
        IEnumerable<UserDto> GetUsers();
        UserDto Login(string username, string password);
        UserDto RegisterUser(UserDto userDto, string password);
        void UpdateUser(UserDto user);
        void UpdatePassword(UserDto userDto, string password);
    }
}
