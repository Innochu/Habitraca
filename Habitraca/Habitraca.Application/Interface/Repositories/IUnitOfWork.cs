using Habitraca.Application.Interface.Repositories;

namespace Habitraca.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
	{
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
	}
}
