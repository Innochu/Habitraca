using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class SecondaryAcademicsRepository : GenericRepository<SecondaryAcademics>, ISecondaryAcademicsRepository
    {
        public SecondaryAcademicsRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(SecondaryAcademics task)
        {
            await DeleteAsync(task);
        }

        public async Task<SecondaryAcademics> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<SecondaryAcademics> UpdateAsync(SecondaryAcademics task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}
