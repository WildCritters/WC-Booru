using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WC.Model.Entity;

namespace WC.Controller.Repositories.Contract
{
    public interface IUserRepository
    {
        User GetUserById(long userId);
        public User GetUserByUsername(string username);
        IEnumerable<User> GetUsers();
        User Login(string username, string password);
        User RegisterUser(User user, string password);
        void UpdateUser(User user);
        void UpdatePassword(User user, string password);
    }
}
