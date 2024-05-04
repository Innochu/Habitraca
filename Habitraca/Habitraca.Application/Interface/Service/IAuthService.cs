using Habitraca.Application.AuthEntity;
using Habitraca.Application.DtoFolder;
using Habitraca.Domain;
using Habitraca.Domain.AuthEntity;
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Interface.Service
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponseDto>> LoginAsync(Login loginDTO);
        Task<ApiResponse<RegisterResponseDto>> RegisterAsync(SignUp userSignup);
        Task<ApiResponse<string>> ResetPasswordAsync(string email, string token, string newPassword);
        Task<ApiResponse<string>> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<ApiResponse<string>> ForgotPasswordAsync(string email);
    }
}
