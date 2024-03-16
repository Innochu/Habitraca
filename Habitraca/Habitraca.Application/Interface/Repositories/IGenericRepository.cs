using System.Linq.Expressions;

namespace Habitraca.Application.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(string id);
		Task<List<T>> GetAllAsync();
		Task<List<T>> FindAsync(Expression<Func<T, bool>> expression);
		Task AddAsync(T entity);
		void Update(T entity);
		Task DeleteAsync(T entity);
		void DeleteAllAsync(List<T> entities);
		Task SaveChangesAsync();
		Task<T> FindSingleAsync(Expression<Func<T, bool>> expression);

    }
}
