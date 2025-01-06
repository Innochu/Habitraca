using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class CareerGrowthRepository : GenericRepository<CareerGrowth>, ICareerGrowthRepository
    {
        public CareerGrowthRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(CareerGrowth task)
        {
            await DeleteAsync(task);
        }

        public async Task<CareerGrowth> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<CareerGrowth> UpdateAsync(CareerGrowth task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}