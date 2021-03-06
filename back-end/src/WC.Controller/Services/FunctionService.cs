using WC.Context.Configurations;
using WC.Model.Entity;

namespace WC.Model.Services
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
