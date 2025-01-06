using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class PhysicalFitnessRepository : GenericRepository<PhysicalFitness>, IPhysicalFitnessRepository
    {
        public PhysicalFitnessRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(PhysicalFitness task)
        {
            await DeleteAsync(task);
        }

        public async Task<PhysicalFitness> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<PhysicalFitness> UpdateAsync(PhysicalFitness task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}
