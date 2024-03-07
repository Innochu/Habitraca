using Habitraca.Application.DtoFolder;
using Habitraca.Domain;
using Habitraca.Domain.AuthEntity;

namespace Habitraca.Application.Interface.Service
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponseDto>> LoginAsync(Login loginDTO);
    }
}
