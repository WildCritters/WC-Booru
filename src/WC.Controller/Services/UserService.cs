using WC.Context.Configurations;
using WC.Model.Security;

namespace WC.Controller.Services
{
    public class UserService : IUserService {
        private readonly UnitOfWork unitOfWork;

        private readonly WildCrittersRepository<User> userRepository;

        public UserService(UnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
            this.userRepository = unitOfWork.userRepository;
        }
    }  
}