
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Interface.Repositories
{
    public interface IRewardRepository
    {
        Task<List<Reward>> GetAll(); 
        Task<IEnumerable<Reward>> GetByPoints(int points); 
        Task<IEnumerable<Reward>> GetByWordSearch(string word);  
        Task<IEnumerable<Reward>> GetByPointsRange(int minPoints, int maxPoints); 

    }
}
