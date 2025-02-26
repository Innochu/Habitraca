using Habitraca.Application.Interface.Repositories;
using Habitraca.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Habitraca.Domain;

namespace Habitraca.Application.Implementation
{
    public class RewardService
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly ILogger<RewardService> _logger;

        public RewardService(IRewardRepository rewardRepository, ILogger<RewardService> logger)
        {
            _rewardRepository = rewardRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<List<Reward>>> GetAllRewards()
        {
            try
            {
                var rewards = await _rewardRepository.GetAll();
                if (rewards == null || rewards.Count == 0)
                {
                    _logger.LogWarning("No rewards found.");
                    return new ApiResponse<List<Reward>>(false, "No rewards found.", StatusCodes.Status404NotFound, null, new List<string>());
                }

                _logger.LogInformation("Rewards retrieved successfully.");
                return new ApiResponse<List<Reward>>(true, "Rewards retrieved successfully.", StatusCodes.Status200OK, rewards, new List<string>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllRewards: {ex.Message}", ex);
                return new ApiResponse<List<Reward>>(false, "An error occurred while retrieving rewards.", StatusCodes.Status500InternalServerError, null, new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<Reward>>> GetRewardsByPoints(int points)
        {
            try
            {
                var rewards = await _rewardRepository.GetByPoints(points);
                if (rewards == null || !rewards.Any())
                {
                    _logger.LogWarning($"No rewards found with {points} points.");
                    return new ApiResponse<IEnumerable<Reward>>(false, "No rewards found with the specified points.", StatusCodes.Status404NotFound, null, new List<string>());
                }

                _logger.LogInformation($"Rewards retrieved successfully for {points} points.");
                return new ApiResponse<IEnumerable<Reward>>(true, "Rewards retrieved successfully.", StatusCodes.Status200OK, rewards, new List<string>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRewardsByPoints: {ex.Message}", ex);
                return new ApiResponse<IEnumerable<Reward>>(false, "An error occurred while retrieving rewards by points.", StatusCodes.Status500InternalServerError, null, new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<Reward>>> GetRewardsByWordSearch(string word)
        {
            try
            {
                var rewards = await _rewardRepository.GetByWordSearch(word);
                if (rewards == null || !rewards.Any())
                {
                    _logger.LogWarning($"No rewards found containing the word '{word}'.");
                    return new ApiResponse<IEnumerable<Reward>>(false, $"No rewards found containing the word '{word}'.", StatusCodes.Status404NotFound, null, new List<string>());
                }

                _logger.LogInformation($"Rewards retrieved successfully for word search '{word}'.");
                return new ApiResponse<IEnumerable<Reward>>(true, "Rewards retrieved successfully.", StatusCodes.Status200OK, rewards, new List<string>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRewardsByWordSearch: {ex.Message}", ex);
                return new ApiResponse<IEnumerable<Reward>>(false, "An error occurred while searching for rewards.", StatusCodes.Status500InternalServerError, null, new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<Reward>>> GetRewardsByPointsRange(int minPoints, int maxPoints)
        {
            try
            {
                var rewards = await _rewardRepository.GetByPointsRange(minPoints, maxPoints);
                if (rewards == null || !rewards.Any())
                {
                    _logger.LogWarning($"No rewards found in the range of {minPoints} to {maxPoints} points.");
                    return new ApiResponse<IEnumerable<Reward>>(false, "No rewards found in the specified points range.", StatusCodes.Status404NotFound, null, new List<string>());
                }

                _logger.LogInformation($"Rewards retrieved successfully for the points range {minPoints} to {maxPoints}.");
                return new ApiResponse<IEnumerable<Reward>>(true, "Rewards retrieved successfully.", StatusCodes.Status200OK, rewards, new List<string>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRewardsByPointsRange: {ex.Message}", ex);
                return new ApiResponse<IEnumerable<Reward>>(false, "An error occurred while retrieving rewards in the points range.", StatusCodes.Status500InternalServerError, null, new List<string> { ex.Message });
            }
        }
    }
}
