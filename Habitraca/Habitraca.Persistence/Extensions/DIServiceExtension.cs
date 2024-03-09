using Habitraca.Application.Interface.Service;
using Habitraca.Application.Services;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Savi_Thrift.Application.Interfaces.Repositories;
using Savi_Thrift.Persistence.Repositories;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace Habitraca.Persistence.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HabitDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("HabitracaConnection")));

            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<IAuthService, AuthService>();


            // Register GenericRepository
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

           


            //return services;
        }
    }
}