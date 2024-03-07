using Habitraca.Persistence.DbContextFolder;
using Savi_Thrift.Application.Interfaces.Repositories;

namespace Savi_Thrift.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly HabitDbContext _saviDbContext;

		public UnitOfWork(HabitDbContext saviDbContext)
		{
			_saviDbContext = saviDbContext;		
        }
        public async Task<int> SaveChangesAsync()
		{
			return await _saviDbContext.SaveChangesAsync();
		}
		public void Dispose()
		{
			_saviDbContext.Dispose();
		}
	}
}
