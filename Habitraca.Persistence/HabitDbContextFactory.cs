using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace Habitraca.Persistence.DbContextFolder
{
    public class HabitDbContextFactory : IDesignTimeDbContextFactory<HabitDbContext>
    {
        public HabitDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HabitDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HabitracaConnection");

            optionsBuilder.UseSqlServer(connectionString); 

            return new HabitDbContext(optionsBuilder.Options);
        }
    }
} 
