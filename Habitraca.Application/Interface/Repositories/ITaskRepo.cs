using Habitraca.Domain.Entities;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Domain.Enum;

namespace Habitraca.Application.Interface.Repositories
{
   public interface ITaskRepository
    {
        Task<HabitTask> GetByIdAsync(int id);
        Task<IEnumerable<HabitTask>> GetAllAsync();
        Task<IEnumerable<HabitTask>> GetByUserIdAsync(string userId);
        Task<IEnumerable<HabitTask>> GetByCategoryAsync(TaskCategory category);
        Task<IEnumerable<HabitTask>> GetActiveTasksAsync();
        Task AddRangeAsync(IEnumerable<HabitTask> tasks);
        Task CommitAsync();
        Task AddAsync(HabitTask task);
        void Update(HabitTask task);
        void Delete(HabitTask task);
        Task<List<HabitTask>> GetByTaskIdsAsync(IEnumerable<Guid> taskIds);
    }

    public interface ITaskCompletionRepository
    {
        Task<TaskCompletion> GetByIdAsync(int id);
        Task<IEnumerable<TaskCompletion>> GetByUserIdAsync(string userId);
        Task<IEnumerable<TaskCompletion>> GetByDateRangeAsync(string userId, DateTime start, DateTime end);
        Task AddAsync(TaskCompletion completion);
        Task AddRangeAsync(IEnumerable<TaskCompletion> tasks);
        Task<List<Graph>> GetTotalPointsPerDayAsync(string userId, DateTime startDate, DateTime endDate);
    }
}
