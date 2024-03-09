using Habitraca.Application.Interface.Repositories;
using Habitraca.Persistence.DbContextFolder;
using Habitraca.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Savi_Thrift.Application.Interfaces.Repositories;

namespace Savi_Thrift.Persistence.Repositories
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
			return await _context.SaveChangesAsync();
		}
		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
