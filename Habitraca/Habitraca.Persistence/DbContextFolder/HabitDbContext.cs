using Habitraca.Application.AuthEntity;
using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Habitraca.Persistence.DbContextFolder
{
    public class HabitDbContext : IdentityDbContext<User>
    {
        public HabitDbContext(DbContextOptions<HabitDbContext> options) : base(options)
        {
            
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    FirstName = "Innocent",
                    LastName = "Chukwudi",
                    Email = "Chuksinnocent1@gmail.com",
                    PhoneNumber = "07013238817",
                    Password = "Password",
                  
                }
                );

            
        }
    }
}
