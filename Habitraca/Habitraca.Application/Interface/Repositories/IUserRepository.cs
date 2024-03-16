using Habitraca.Domain.Entities;
using Habitraca.Application.Interfaces.Repositories;

namespace Habitraca.Application.Interface.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task DeleteUser(User user);
    }
}
