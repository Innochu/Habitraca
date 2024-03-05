using Habitraca.Application.AuthEntity;
using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Habitraca.Persistence.DbContextFolder
{
    public class HabitDb : IdentityDbContext<User>
    {
        public HabitDb(DbContextOptions<HabitDb> options) : base(options)
        {
            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        item.Entity.Id = Guid.NewGuid();
                        item.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    FirstName = "Innocent",
                    LastName = "Chukwudi",
                    Email = "Chuksinnocent1@gmail.com",
                    PhoneNumber = "07013238817",
                  
                }
                );

            
        }
    }
}
