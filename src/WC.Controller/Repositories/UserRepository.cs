using System.Linq;
using WC.Context;
using WC.Controller.Repositories.Contract;
using WC.Model.Security;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WC.Controller.Repositories
{
    public class UserRepository : IUserRepository
    {
        internal WildCrittersDBContext Context { get; set; }

        public UserRepository(WildCrittersDBContext context) => this.Context = context;

        public User GetUserById(int userId)
        {
            return this.Context.Users
                .Include(x => x.Role)
                .Where(x => x.Id == userId)
                .FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.Context.Users.AsEnumerable();
        }
    }
}
