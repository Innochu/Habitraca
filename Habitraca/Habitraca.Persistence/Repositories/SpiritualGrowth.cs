using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class SpiritualGrowthRepository : GenericRepository<SpiritualGrowth>, ISpiritualGrowthRepository
    {
        public SpiritualGrowthRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(SpiritualGrowth task)
        {
            await DeleteAsync(task);
        }

        public async Task<SpiritualGrowth> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<SpiritualGrowth> UpdateAsync(SpiritualGrowth task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}
