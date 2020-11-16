using System;
using System.Collections.Generic;
using System.Text;
using WC.Model.Security;

namespace WC.Controller.Repositories.Contract
{
    public interface IUserRepository
    {
        public User GetUserById(int userId);
        public IEnumerable<User> GetUsers();
    }
}
