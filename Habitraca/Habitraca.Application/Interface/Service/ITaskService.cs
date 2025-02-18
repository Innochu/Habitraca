
using Habitraca.Domain;
using Habitraca.Domain.Entities;
using Habitraca.Domain.Enum;

namespace Habitraca.Application.Interface.Service
{
    public interface ITaskService
    {
         Task<ApiResponse<string>> DailyTaskRecord(string id);
          Task<ApiResponse<string>> WeeklyTaskRecord(string id);
           Task<ApiResponse<string>> MonthlyTaskRecord(string id);
           Task<int> GetTotalActiveTasksCount(string userId);
           Task<ApiResponse<string>> AddUserTask(string id, List<TaskDto> listOfTasks) ;
           Task<ApiResponse<List<TaskPool>>> GetAllTaskPoolByCategory(TaskCategory category);
        Task<ApiResponse<List<HabitTask>>> GetAllSelectedTask(string id);
        Task<ApiResponse<List<TaskCompletion>>> GetAllCompletedTask(string id, TaskFrequency taskFrequency);
        Task<ApiResponse<string>> AddCompletedTask(string id, List<CompletedTaskDto> listOfTasks);
        Task<ApiResponse<int>> GetDailyCompletedTaskPoints(string id);
    }
}
