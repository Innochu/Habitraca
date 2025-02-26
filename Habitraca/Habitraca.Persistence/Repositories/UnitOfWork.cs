using Habitraca.Application.Interface.Repositories;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Persistence.DbContextFolder;
using Microsoft.EntityFrameworkCore;

namespace Habitraca.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HabitDbContext _context;
        private bool disposed = false;

        public UnitOfWork(HabitDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            TaskRepository = new TaskRepository(_context);
            TaskCompletionRepository = new TaskCompletionRepository(_context);
            TaskPoolRepository = new TaskPoolRepository(_context);
            RewardRepository = new RewardRepository(_context);
        }

        public IUserRepository UserRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public ITaskCompletionRepository TaskCompletionRepository { get; }
        public IRewardRepository RewardRepository { get; }
        
        // Add this property to support the TaskService
        public HabitDbContext Context => _context;

        public ITaskPoolRepository TaskPoolRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error occurred while saving changes to the database.", ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}