using Habitraca.Application.Interface.Repositories;
using Habitraca.Persistence.DbContextFolder;
using Habitraca.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Habitraca.Application.Interfaces.Repositories;

namespace Habitraca.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly HabitDbContext _context;

		public UnitOfWork(HabitDbContext context)
		{
            _context = context;		
			UserRepository = new UserRepository(_context);
        }

        public IUserRepository UserRepository { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception or handle it as needed
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

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


  //      public void Dispose()
		//{
		//	_context.Dispose();
		//}
	}
}
