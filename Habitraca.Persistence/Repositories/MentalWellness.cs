// using Habitraca.Application.Interface.Repositories;
// using Habitraca.Domain.Entities;
// using Habitraca.Persistence.DbContextFolder;

// namespace Habitraca.Persistence.Repositories
// {
//     public class MentalWellnessRepository : GenericRepository<MentalWellness>, IMentalWellnessRepository
//     {
//         public MentalWellnessRepository(HabitDbContext context) : base(context)
//         {
            
//         }

//         public async Task DeleteUser(MentalWellness task)
//         {
//             await DeleteAsync(task);
//         }

//         public async Task<MentalWellness> GetUserByIdAsync(string id) => await GetByIdAsync(id);

//         public async Task<MentalWellness> UpdateAsync(MentalWellness task)
//         {
//             Update(task);
//             await SaveChangesAsync();
//             return task;
//         }

//     }
// }
