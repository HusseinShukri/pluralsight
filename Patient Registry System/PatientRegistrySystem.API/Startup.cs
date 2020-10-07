using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.Services;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.DB.Entities;

namespace PatientRegistrySystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            #region GenericServices
            services.AddScoped<IGenericRepository<User>, UserRepository>();
            #endregion
            #region ControllerServices
            services.AddScoped<IUserService, UserService>();
            #endregion
            
            services.AddAutoMapper(typeof(DB.Profiles.MapperProfile).Assembly);
            services.AddDbContext<PatientContext>(options =>
            {
                options
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data Source=DESKTOP-0CVKC97;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog = PatientRegistrySystem");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
