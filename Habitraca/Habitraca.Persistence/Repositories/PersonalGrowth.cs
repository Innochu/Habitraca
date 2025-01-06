// using Habitraca.Application.Interface.Repositories;
// using Habitraca.Domain.Entities;
// using Habitraca.Persistence.DbContextFolder;

// namespace Habitraca.Persistence.Repositories
// {
//     public class PersonalGrowthRepository : GenericRepository<PersonalGrowth>, IPersonalGrowthRepository
//     {
//         public PersonalGrowthRepository(HabitDbContext context) : base(context)
//         {
            
//         }

//         public async Task DeleteUser(PersonalGrowth task)
//         {
//             await DeleteAsync(task);
//         }

//         public async Task<PersonalGrowth> GetUserByIdAsync(string id) => await GetByIdAsync(id);

//         public async Task<PersonalGrowth> UpdateAsync(PersonalGrowth task)
//         {
//             Update(task);
//             await SaveChangesAsync();
//             return task;
//         }

//     }
// }
