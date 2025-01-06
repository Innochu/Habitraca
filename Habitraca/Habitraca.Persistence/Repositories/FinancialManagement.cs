using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;

namespace Habitraca.Persistence.Repositories
{
    public class FinancialManagementRepository : GenericRepository<FinancialManagement>, IFinancialManagementRepository
    {
        public FinancialManagementRepository(HabitDbContext context) : base(context)
        {
            
        }

        public async Task DeleteUser(FinancialManagement task)
        {
            await DeleteAsync(task);
        }

        public async Task<FinancialManagement> GetUserByIdAsync(string id) => await GetByIdAsync(id);

        public async Task<FinancialManagement> UpdateAsync(FinancialManagement task)
        {
            Update(task);
            await SaveChangesAsync();
            return task;
        }

    }
}
