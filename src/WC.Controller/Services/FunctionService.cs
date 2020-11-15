using WC.Context.Configurations;
using WC.Model.Security;
public class FunctionService : IFunctionService {
    private readonly UnitOfWork unitOfWork;

    private readonly WildCrittersRepository<Function> functionRepository;

    public FunctionService(UnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
        this.functionRepository = unitOfWork.functionRepository;
    }
}