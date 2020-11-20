using System.Collections.Generic;
using WC.Model.Security;

namespace WC.Controller.Services.Contract
{
    public interface IUserService
    {
        public bool ExistUsername(string username);
        User GetUser(int userId);
        IEnumerable<User> GetUsers();
        User Login(string username, string password);
    }
}
