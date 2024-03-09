using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;
using Savi_Thrift.Persistence.Repositories;

namespace Habitraca.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HabitDbContext context) : base(context)
        {
            
        }
    }
}
