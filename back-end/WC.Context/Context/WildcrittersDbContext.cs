using Microsoft.EntityFrameworkCore;
using WC.Model.Entity;

namespace WC.Context
{
    public class WildCrittersDBContext : DbContext
    {
        public WildCrittersDBContext() {}

        public WildCrittersDBContext(DbContextOptions<WildCrittersDBContext> options)
            : base(options) {}

        public DbSet<User> Emotes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<RoleFunction> RoleFunctions { get; set; } 
        public DbSet<User> Users { get; set; }
    }
}