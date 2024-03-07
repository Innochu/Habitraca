namespace Savi_Thrift.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
	{
        Task<int> SaveChangesAsync();
	}
}
