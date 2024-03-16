using Habitraca.Application.Interface.Service;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Domain;
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<User>> DeleteUser(string id)
        {
            var findUser = await _unitOfWork.UserRepository.GetByIdAsync(id);

            try
            {
                if (findUser != null)
                {
                    // Await the deletion operation to ensure it completes before continuing
                    await _unitOfWork.UserRepository.DeleteAsync(findUser);

                    // Check if deletion succeeds
                    var deletedUser = await _unitOfWork.UserRepository.FindSingleAsync(u => u.Id == id);
                    if (deletedUser == null)
                    {
                        return ApiResponse<User>.Success(findUser, "User successfully deleted", 200);
                    }
                    else
                    {
                        return ApiResponse<User>.Failed("Error occurred while deleting user. User still exists.", 500, new List<string>());
                    }
                }
                else
                {
                    return ApiResponse<User>.Failed("No user found", 400, new List<string>());
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<User>.Failed("Error occurs while deleting user. Try again.", 500, new List<string>() { ex.Message });
            }
        }

    }
}
