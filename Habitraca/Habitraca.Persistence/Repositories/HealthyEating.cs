// using Habitraca.Application.Interface.Repositories;
// using Habitraca.Domain.Entities;
// using Habitraca.Persistence.DbContextFolder;

// namespace Habitraca.Persistence.Repositories
// {
//     public class HealthyEatingRepository : GenericRepository<HealthyEating>, IHealthyEatingRepository
//     {
//         public HealthyEatingRepository(HabitDbContext context) : base(context)
//         {
            
//         }

//         public async Task DeleteUser(HealthyEating task)
//         {
//             await DeleteAsync(task);
//         }

//         public async Task<HealthyEating> GetUserByIdAsync(string id) => await GetByIdAsync(id);

//         public async Task<HealthyEating> UpdateAsync(HealthyEating task)
//         {
//             Update(task);
//             await SaveChangesAsync();
//             return task;
//         }

//     }
// }
