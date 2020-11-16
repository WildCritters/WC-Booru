using System.Collections.Generic;
using System.Linq;
using WC.Context.Configurations;
using WC.Controller.Repositories;
using WC.Controller.Repositories.Contract;
using WC.Model.Security;

namespace WC.Controller.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository repository)
        {
            this.userRepository = repository;
        }

        public User GetUser(int userId)
        {
            return this.userRepository.GetUserById(userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return this.userRepository.GetUsers();
        }
    }
}