using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class ComputerLiteracyRepository : GenericRepository<ComputerLiteracy>, IComputerLiteracyRepository
    {
        public ComputerLiteracyRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(ComputerLiteracy task)
        {
            await DeleteAsync(task);
        }

        public async Task<ComputerLiteracy> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<ComputerLiteracy> UpdateAsync(ComputerLiteracy task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}