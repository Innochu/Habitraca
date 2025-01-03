
using Habitraca.Application.Interface.Service;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Domain;
using Microsoft.AspNetCore.Http;

namespace Habitraca.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<string>> DailyTaskRecord(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed("User with this phone number already exists.", StatusCodes.Status400BadRequest, new List<string>());
            }
             var isExist = await unitOfWork.UserRepository.GetUserByIdAsync(id);
           if(isExist == null)
           {
            return new ApiResponse<string>(false, "User does not exist.", StatusCodes.Status404NotFound, null, new List<string>());
           }
           
          var response = string.Format("{0}/{1}", isExist.DailyTaskDone, isExist.DailyTaskAssigned);
          
           return new ApiResponse<string>(true, "DailyTaskRecord displayed successfully", 200, response, new List<string>());
            
        }

        public async Task<ApiResponse<string>> MonthlyTaskRecord(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed("User with this phone number already exists.", StatusCodes.Status400BadRequest, new List<string>());
            }
             var isExist = await unitOfWork.UserRepository.GetUserByIdAsync(id);
           if(isExist == null)
           {
            return new ApiResponse<string>(false, "User does not exist.", StatusCodes.Status404NotFound, null, new List<string>());
           }
           
          var response = string.Format("{0}/{1}", isExist.MonthlyTaskDone, isExist.MonthlyTaskAssigned);
          
           return new ApiResponse<string>(true, "MonthlyTaskRecord displayed successfully", 200, response, new List<string>());
            
        }

        public async Task<ApiResponse<string>> WeeklyTaskRecord(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed("User with this phone number already exists.", StatusCodes.Status400BadRequest, new List<string>());
            }
             var isExist = await unitOfWork.UserRepository.GetUserByIdAsync(id);
           if(isExist == null)
           {
            return new ApiResponse<string>(false, "User does not exist.", StatusCodes.Status404NotFound, null, new List<string>());
           }
           
          var response = string.Format("{0}/{1}", isExist.WeeklyTaskDone, isExist.WeeklyTaskAssigned);
          
           return new ApiResponse<string>(true, "WeeklyTaskRecord displayed successfully", 200, response, new List<string>());
            
        }
    }
}