using System.Collections.Generic;
using WC.Model.Security;

namespace WC.Controller.Services.Contract
{
    public interface IUserService
    {
        User GetUser(int userId);
        IEnumerable<User> GetUsers();
        User Login(string username, string password);
    }
}
