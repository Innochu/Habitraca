using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Habitraca.Persistence.DbContextFolder
{
    public class HabitDbContext : IdentityDbContext<User>
    {
        public HabitDbContext(DbContextOptions<HabitDbContext> options) : base(options)
        {

        } 
        public DbSet<PrimaryAcademics> PrimaryAcademicTasks { get; set; }
        public DbSet<SecondaryAcademics> SecondaryAcademicTasks { get; set; }
        public DbSet<TertiaryAcademics> TertiaryAcademicTasks { get; set; }
        public DbSet<CareerGrowth> CareerGrowths { get; set; }
        public DbSet<PhysicalFitness> PhysicalFitnesss { get; set; }
        public DbSet<MentalWellness> MentalWellnesss { get; set; }
        public DbSet<Leadership> Leaderships { get; set; }
        public DbSet<FinanacialManagement> FinanacialManagements { get; set; }
        public DbSet<SocialDevelopment> SocialDevelopments { get; set; }
        public DbSet<PersonalGrowth> PersonalGrowths { get; set; }
        public DbSet<SpiritualGrowth> SpiritualGrowths { get; set; }
        public DbSet<HealthyEating> HealthyEatings { get; set; }
        public DbSet<ComputerLiteracy> ComputerLiteracys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary key for IdentityUserLogin
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });

            // Seed initial data for User entity
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
