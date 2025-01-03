
using Habitraca.Domain;

namespace Habitraca.Application.Interface.Service
{
    public interface ITaskService
    {
         Task<ApiResponse<string>> DailyTaskRecord(string id);
          Task<ApiResponse<string>> WeeklyTaskRecord(string id);
           Task<ApiResponse<string>> MonthlyTaskRecord(string id);
    }
}
