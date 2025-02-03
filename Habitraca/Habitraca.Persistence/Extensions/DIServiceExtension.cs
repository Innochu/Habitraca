using Habitraca.Application.Implementation;
using Habitraca.Application.Interface.Repositories;
using Habitraca.Application.Interface.Service;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Application.Services;
using Habitraca.Domain.EmailFolder;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;
using Habitraca.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;


namespace Habitraca.Persistence.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<HabitDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("HabitracaConnection")));


            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<IAuthService, AuthService>();
             services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IGraphService, GraphService>();
            // Register Email services
            var emailSettings = new EmailSettings();
            configuration.GetSection("EmailSettings").Bind(emailSettings);
            services.AddSingleton(emailSettings);

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();


            
         

            // Register GenericRepository
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

           

        }

       
    }
}