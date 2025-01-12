using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Domain.Enum;
using Habitraca.Persistence.DbContextFolder;
using Microsoft.EntityFrameworkCore;

namespace Habitraca.Persistence.Repositories
{
    public class TaskPoolRepository : ITaskPoolRepository
    {
        private readonly HabitDbContext _context;

        public TaskPoolRepository(HabitDbContext context)
        {
            _context = context;
        }

        public async Task<TaskPool> GetByIdAsync(int id)
        {
            return await _context.TaskPools.FindAsync(id);
        }

        public async Task<IEnumerable<TaskPool>> GetAllAsync()
        {
            return await _context.TaskPools.ToListAsync();
        }


        public async Task<IEnumerable<TaskPool>> GetByCategoryAsync(TaskCategory category)
        {
            return await _context.TaskPools
                .Where(t => t.Category == category)
                .ToListAsync();
        }
        public async Task<IEnumerable<TaskPool>> GetActiveTasksAsync()
        {
            return await _context.TaskPools
                .Where(t => t.IsActive)
                .ToListAsync();
        }

        public async Task AddAsync(TaskPool task)
        {
            await _context.TaskPools.AddAsync(task);
        }

        public void Update(TaskPool task)
        {
            _context.TaskPools.Update(task);
        }

        public void Delete(TaskPool task)
        {
            _context.TaskPools.Remove(task);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}