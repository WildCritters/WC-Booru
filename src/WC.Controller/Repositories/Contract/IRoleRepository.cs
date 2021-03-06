using System;
using System.Collections.Generic;
using System.Text;
using WC.Model.Entity;

namespace WC.Controller.Repositories.Contract
{
    public interface IRoleRepository
    {
        Role GetRoleByName(string name); 
    }
}
