using Microsoft.EntityFrameworkCore;
using ItemsDotNetApi.Data;
using EFCore.AutomaticMigrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ItemsDotNetApi.Extensions
{
    public static class StartupDbExtensions
    {
        public static async void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var ItemContext = services.GetRequiredService<AppDbContext>();

            try
            {
                ItemContext.Database.EnsureCreated();
                ItemContext.Database.Migrate();
                
                DBInitializerSeedData.InitializeDatabase(ItemContext);
            }
            catch (Exception ex)
            {

                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError($"cannt do migration {ex.Message}");
            }


            



        }
    }
}
