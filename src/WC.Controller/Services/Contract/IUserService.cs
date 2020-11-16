using System.Collections.Generic;
using WC.Model.Security;

public interface IUserService
{
    public User GetUser(int userId);
    public IEnumerable<User> GetUsers();
}