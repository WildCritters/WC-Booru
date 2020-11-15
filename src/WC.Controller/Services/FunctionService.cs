using WC.Context.Configurations;
using WC.Model.Security;

namespace WC.Controller.Services
{
    public class FunctionService : IFunctionService {
        private readonly UnitOfWork unitOfWork;

        private readonly WildCrittersRepository<Function> functionRepository;

        public FunctionService(UnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
            this.functionRepository = unitOfWork.functionRepository;
        }
    }    
}
