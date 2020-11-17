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

        public User Login(string username, string password)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName.Equals(username));

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passHash, byte[] passSalt){
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return Enumerable.SequenceEqual(computedHash, passHash);
            }
        }
    }
}
