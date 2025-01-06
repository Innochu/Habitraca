
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
       
       
        public async Task<ApiResponse<string>> PostTaskAssigned(string id)
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
           var taskCountService = new TaskService(unitOfWork);
    var totalActiveTasks = await taskCountService.GetTotalActiveTasksCount(id);
   
    return new ApiResponse<string>(
        true, 
        "WeeklyTaskRecord displayed successfully", 
        StatusCodes.Status200OK, 
        totalActiveTasks.ToString(), 
        new List<string>()
    );
        }
    

     public async Task<int> GetTotalActiveTasksCount(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentNullException(nameof(userId));

        var totalCount = 0;

        // Add counts from each task table
      totalCount += await unitOfWork.CareerGrowthRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.ComputerLiteracyRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.FinancialManagementRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.HealthyEatingRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.LeadershipRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.MentalWellnessRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.PersonalGrowthRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.PhysicalFitnessRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.PrimaryAcademicsRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.SecondaryAcademicsRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.SocialDevelopmentRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.SpiritualGrowthRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);
totalCount += await unitOfWork.TertiaryAcademicsRepository.CountAsync(x => x.Id == Guid.Parse(userId) && x.IsActive);

        return totalCount;
    }
}
}