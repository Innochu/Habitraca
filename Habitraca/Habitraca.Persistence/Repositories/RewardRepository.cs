using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;
using Microsoft.EntityFrameworkCore;

namespace Habitraca.Persistence.Repositories
{
    public class RewardRepository :  IRewardRepository
    {
        private readonly HabitDbContext _context;
        public RewardRepository(HabitDbContext context)
        {
            _context = context;
        }
        public async Task<List<Reward>> GetAll()
        {
            return await _context.Rewards.ToListAsync();
        }

        public async Task<IEnumerable<Reward>> GetByPoints(int points)
        {
            return await _context.Rewards
                                 .Where(r => r.Point == points)
                                 .ToListAsync();
        }


        public async Task<IEnumerable<Reward>> GetByWordSearch(string word)
        {
            return await _context.Rewards
                                 .Where(t => t.Description.Contains(word)) 
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Reward>> GetByPointsRange(int minPoints, int maxPoints)
        {
            return await _context.Rewards
                .Where(r => r.Point >= minPoints && r.Point <= maxPoints)
                .ToListAsync();
        }

    }
}
