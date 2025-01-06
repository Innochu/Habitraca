using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class PrimaryAcademicsRepository : GenericRepository<PrimaryAcademics>, IPrimaryAcademicsRepository
    {
        public PrimaryAcademicsRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(PrimaryAcademics task)
        {
            await DeleteAsync(task);
        }

        public async Task<PrimaryAcademics> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<PrimaryAcademics> UpdateAsync(PrimaryAcademics task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}
