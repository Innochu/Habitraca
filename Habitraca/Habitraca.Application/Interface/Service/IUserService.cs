using Habitraca.Domain;
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Interface.Service
{
    public interface IUserService
    {
        Task<ApiResponse<User>> DeleteUser(string id);
    }
}
