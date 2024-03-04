using Habitraca.Persistence.DbContextFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Habitraca.Persistence.Extension
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<HabitDb>(options => 
            options.UseSqlServer(config.GetConnectionString("HabitracaConnection")));
        }
    }
}