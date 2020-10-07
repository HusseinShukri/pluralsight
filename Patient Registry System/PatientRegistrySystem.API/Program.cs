using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PatientRegistrySystem.DB.Contexts;

namespace PatientRegistrySystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new PatientContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
