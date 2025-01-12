
using Habitraca.Domain.Entities;
using Habitraca.Domain.Enum;

namespace Habitraca.Application.Interface.Repositories
{
    public interface ITaskPoolRepository
    {
        Task<TaskPool> GetByIdAsync(int id);
        Task<IEnumerable<TaskPool>> GetAllAsync();
        Task<IEnumerable<TaskPool>> GetByCategoryAsync(TaskCategory category);
        Task<IEnumerable<TaskPool>> GetActiveTasksAsync();
        Task AddAsync(TaskPool task);
        void Update(TaskPool task);
        void Delete(TaskPool task);
        Task CommitAsync();

    }
}
