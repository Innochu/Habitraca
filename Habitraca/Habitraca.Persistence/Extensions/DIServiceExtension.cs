using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace Habitraca.Persistence.Extensions
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HabitDb>(options => 
            options.UseSqlServer(configuration.GetConnectionString("HabitracaConnection")));

          

            return services;
        }
    }
}