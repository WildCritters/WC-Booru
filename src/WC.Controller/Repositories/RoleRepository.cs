using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WC.Context;
using WC.Controller.Repositories.Contract;
using WC.Model.Entity;

namespace WC.Controller.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        internal WildCrittersDBContext Context { get; set; }
        public RoleRepository(WildCrittersDBContext context) => this.Context = context;

        public Role GetRoleByName(string name)
        {
            return this.Context.Roles
                .Where(x => x.Name.ToLower().Equals(name.ToLower()))
                .FirstOrDefault();
        }
    }
}
