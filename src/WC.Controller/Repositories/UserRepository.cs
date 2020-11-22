﻿using System.Linq;
using WC.Context;
using WC.Controller.Repositories.Contract;
using WC.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WC.Model.DTO;
using System.Threading.Tasks;

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

        public User GetUserByUsername(string username)
        {
            return this.Context.Users
                .Where(x => x.UserName.ToLower().Equals(username.ToLower()))
                .FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.Context.Users.AsEnumerable();
        }

        public User Login(string username, string password)
        {
            var user = this.Context.Users.Include(x => x.Role).FirstOrDefault(x => x.UserName.Equals(username));

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

        public User RegisterUser(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            this.Context.Users.Add(user);
            this.Context.SaveChanges();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
