// using Habitraca.Application.Interface.Repositories;
// using Habitraca.Domain.Entities;
// using Habitraca.Persistence.DbContextFolder;

// namespace Habitraca.Persistence.Repositories
// {
//     public class TertiaryAcademicsRepository : GenericRepository<TertiaryAcademics>, ITertiaryAcademicsRepository
//     {
//         public TertiaryAcademicsRepository(HabitDbContext context) : base(context)
//         {
            
//         }

//         public async Task DeleteUser(TertiaryAcademics task)
//         {
//             await DeleteAsync(task);
//         }

//         public async Task<TertiaryAcademics> GetUserByIdAsync(string id) => await GetByIdAsync(id);

//         public async Task<TertiaryAcademics> UpdateAsync(TertiaryAcademics task)
//         {
//             Update(task);
//             await SaveChangesAsync();
//             return task;
//         }

//     }
// }