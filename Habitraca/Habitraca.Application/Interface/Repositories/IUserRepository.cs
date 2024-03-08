using Habitraca.Domain.Entities;
using Savi_Thrift.Application.Interfaces.Repositories;

namespace Habitraca.Application.Interface.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
