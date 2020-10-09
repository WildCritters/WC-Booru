using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WC.Context.Configurations
{
    public class WildCrittersDBContextFactory : IDesignTimeDbContextFactory<WildCrittersDBContext>
    {
        public WildCrittersDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WildCrittersDBContext>();

            var configuration = AppConfiguration.Get(ContentDirectoryFinder.CalculateContentRootFolder());

            var connectionString = configuration.GetConnectionString("Default");

            builder.UseMySql(connectionString, b => b.MigrationsAssembly(typeof(WildCrittersDBContext).Assembly.GetName().Name));

            return new WildCrittersDBContext(builder.Options);
        }
    }
}