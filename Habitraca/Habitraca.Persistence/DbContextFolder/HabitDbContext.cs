using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Habitraca.Persistence.DbContextFolder
{
    public class HabitDbContext : IdentityDbContext<User>
    {
        public HabitDbContext(DbContextOptions<HabitDbContext> options) : base(options)
        {
        }

        public DbSet<HabitTask> Tasks { get; set; }
        public DbSet<TaskCompletion> TaskCompletions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(p => new { p.LoginProvider, p.ProviderKey });

            modelBuilder.Entity<HabitTask>(entity =>
            {
                entity.HasOne(t => t.User)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(t => t.Category)
                    .HasConversion<string>();

                entity.Property(t => t.Frequency)
                    .HasConversion<string>();
            });

            modelBuilder.Entity<TaskCompletion>(entity =>
            {
                entity.HasOne(tc => tc.User)
                    .WithMany(u => u.CompletedTasks)
                    .HasForeignKey(tc => tc.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(tc => tc.Task)
                    .WithMany()
                    .HasForeignKey(tc => tc.TaskId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data
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