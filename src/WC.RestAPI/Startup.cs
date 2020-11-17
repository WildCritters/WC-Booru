using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using WC.Context;
using WC.Controller.Repositories;
using WC.Controller.Repositories.Contract;
using WC.Controller.Services;
using WC.RestAPI.Configurations;

namespace WC.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WildCrittersDBContext>(opt => opt.UseMySql(Configuration["ConnectionStrings:Default"]));

            ConfigureRepository(services);

            ConfigureService(services);

            services.AddAutoMapper(typeof(MapperCongifuration));

            services.AddTransient<Program>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("WildCritters", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "API WildCritters",
                    Version = "1"
                });
            });

            services.AddControllers();
        }

        public void ConfigureRepository(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/WildCritters/swagger.json", "API WildCritters");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}