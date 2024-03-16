using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;
using Habitraca.Persistence.Repositories;
using System.Threading.Tasks;

namespace Habitraca.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(User user)
        {
            await DeleteAsync(user);
        }

        public async Task<User> GetUserByIdAsync(string id) => await GetByIdAsync(id);
    }
}
