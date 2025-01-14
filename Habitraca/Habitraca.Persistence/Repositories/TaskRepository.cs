using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Domain.Enum;
using Habitraca.Persistence.DbContextFolder;
using Microsoft.EntityFrameworkCore;

namespace Habitraca.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly HabitDbContext _context;

        public TaskRepository(HabitDbContext context)
        {
            _context = context;
        }

        public async Task<HabitTask> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<HabitTask>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<HabitTask>> GetByUserIdAsync(string userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }


public async Task<IEnumerable<HabitTask>> GetByCategoryAsync(TaskCategory category)
        {
            return await _context.Tasks
                .Where(t => t.Category == category)
                .ToListAsync();
        }
        public async Task<IEnumerable<HabitTask>> GetActiveTasksAsync()
        {
            return await _context.Tasks
                .Where(t => t.IsActive)
                .ToListAsync();
        }
        public async Task AddRangeAsync(IEnumerable<HabitTask> tasks)
        {
             await _context.Tasks.AddRangeAsync(tasks);
        }
        public async Task AddAsync(HabitTask task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public void Update(HabitTask task)
        {
            _context.Tasks.Update(task);
        }

        public void Delete(HabitTask task)
        {
            _context.Tasks.Remove(task);
        }

        public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
        public async Task<List<HabitTask>> GetByTaskIdsAsync(IEnumerable<Guid> taskIds)
        {
            return await _context.Tasks.Where(t => taskIds.Contains(t.Id)).ToListAsync();
        }

    }

    public class TaskCompletionRepository : ITaskCompletionRepository
    {
        private readonly HabitDbContext _context;

        public TaskCompletionRepository(HabitDbContext context)
        {
            _context = context;
        }

        public async Task<TaskCompletion> GetByIdAsync(int id)
        {
            return await _context.TaskCompletions.FindAsync(id);
        }

        public async Task<IEnumerable<TaskCompletion>> GetByUserIdAsync(string userId)
        {
            return await _context.TaskCompletions
                .Include(tc => tc.Task)
                .Where(tc => tc.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskCompletion>> GetByDateRangeAsync(string userId, DateTime start, DateTime end)
        {
            return await _context.TaskCompletions
                .Include(tc => tc.Task)
                .Where(tc => tc.UserId == userId && 
                            tc.CompletedAt >= start && 
                            tc.CompletedAt <= end)
                .ToListAsync();
        }
        public async Task<List<Graph>> GetTotalPointsPerDayAsync(string userId, DateTime startDate, DateTime endDate)
        {
            // Query TaskCompletions and project them into GraphData
            var result = await _context.TaskCompletions
                .Where(tc => tc.UserId == userId && tc.CompletedAt >= startDate && tc.CompletedAt <= endDate)
                .GroupBy(tc => tc.CompletedAt.Date)  // Group by date
                .Select(g => new Graph
                {
                    Date = g.Key,  
                    TaskCount = g.Sum(tc => tc.Task.Points) 
                })
                .OrderBy(g => g.Date)  // Optional: Order by date for display
                .ToListAsync();

            return result;
        }


        public async Task AddAsync(TaskCompletion completion)
        {
            await _context.TaskCompletions.AddAsync(completion);
        }

        public async Task AddRangeAsync(IEnumerable<TaskCompletion> tasks)
        {
            await _context.TaskCompletions.AddRangeAsync(tasks);
        }
    }
}