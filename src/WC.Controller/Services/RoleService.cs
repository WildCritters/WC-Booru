using WC.Context.Configurations;
using WC.Model.Security;

public class RoleService : IRoleService {
    
    private readonly UnitOfWork unitOfWork;

    private readonly WildCrittersRepository<Role> roleRepository;

    public RoleService(UnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
        this.roleRepository = unitOfWork.roleRepository;
    }
}