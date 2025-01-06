
using Habitraca.Domain;
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Interface.Service
{
    public interface ITaskService
    {
         Task<ApiResponse<string>> DailyTaskRecord(string id);
          Task<ApiResponse<string>> WeeklyTaskRecord(string id);
           Task<ApiResponse<string>> MonthlyTaskRecord(string id);
           Task<int> GetTotalActiveTasksCount(string userId);
           Task<ApiResponse<string>> AddUserTask(string id, List<TaskDto> listOfTasks) ;
    }
}
