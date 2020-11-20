using System;
using System.Collections.Generic;
using System.Text;
using WC.Model.Security;

namespace WC.Controller.Repositories.Contract
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        public User GetUserByUsername(string username);
        IEnumerable<User> GetUsers();
        User Login(string username, string password);
    }
}
