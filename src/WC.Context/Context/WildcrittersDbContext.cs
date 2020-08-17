using Microsoft.EntityFrameworkCore;
using WC.Model.Security;

namespace WC.Context
{
    public class WildCrittersDBContext : DbContext
    {
        public WildCrittersDBContext() {}

        public WildCrittersDBContext(DbContextOptions<WildCrittersDBContext> options)
            : base(options) {}

        public DbSet<User> Emotes { get; set; }
    }
}