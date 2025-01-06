using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class SocialDevelopmentRepository : GenericRepository<SocialDevelopment>, ISocialDevelopmentRepository
    {
        public SocialDevelopmentRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(SocialDevelopment task)
        {
            await DeleteAsync(task);
        }

        public async Task<SocialDevelopment> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<SocialDevelopment> UpdateAsync(SocialDevelopment task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}
