using Habitraca.Application.Interface.Repositories;

namespace Savi_Thrift.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
	{
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
	}
}
