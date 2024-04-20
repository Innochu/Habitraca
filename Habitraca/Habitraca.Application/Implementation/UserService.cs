using Habitraca.Application.Interface.Service;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Domain;
using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Habitraca.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<User> _signInManager;

        public UserService(IUnitOfWork unitOfWork, SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }

        public async Task<ApiResponse<User>> DeactivateUser(string id)
        {
            try
            {
                var findUser = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

                if (findUser != null)
                {
                    findUser.IsActive = false;
                    await _unitOfWork.UserRepository.UpdateAsync(findUser);
                    
                        await _signInManager.SignOutAsync();
                        return ApiResponse<User>.Success(findUser, "User successfully deactivated", 200);
                }
                else
                {
                    return ApiResponse<User>.Failed("No user found", 400, new List<string>());
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<User>.Failed("Error occurred while deactivating user. Try again.", 500, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<User>> DeleteUser(string id)
        {
          

            try
            {
                var findUser = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

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
