using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class LeadershipRepository : GenericRepository<Leadership>, ILeadershipRepository
    {
        public LeadershipRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(Leadership task)
        {
            await DeleteAsync(task);
        }

        public async Task<Leadership> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<Leadership> UpdateAsync(Leadership task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}
