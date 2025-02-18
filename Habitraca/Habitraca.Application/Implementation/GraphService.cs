
using Habitraca.Application.Interface.Service;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Domain;
using Habitraca.Domain.Entities;
using Habitraca.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace Habitraca.Application.Implementation
{
    public class GraphService : IGraphService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GraphService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<ApiResponse<List<DailyPointsChartDTO>>> GetDailyPointsChartData(string id, int numberOfDays = 7)
        {
            var tasks = await _unitOfWork.TaskCompletionRepository.GetByUserIdAsync(id);
            if (tasks == null || !tasks.Any())
            {
                return new ApiResponse<List<DailyPointsChartDTO>>(
                    false,
                    "No points found",
                    StatusCodes.Status404NotFound,
                    null,
                    new List<string>());
            }

            var endDate = DateTime.UtcNow.Date;
            var startDate = endDate.AddDays(-(numberOfDays - 1));

            var chartData = tasks
                .Where(t => t.Task.Frequency == TaskFrequency.Daily
                       && t.CompletedAt.Date >= startDate
                       && t.CompletedAt.Date <= endDate)
                .GroupBy(t => t.CompletedAt.Date)
                .Select(group => new DailyPointsChartDTO
                {
                    Date = group.Key,
                    Points = group.Sum(t => t.Task.Points)
                })
                .OrderBy(x => x.Date)
                .ToList();

            // Fill in missing dates with zero points
            var completeChartData = Enumerable.Range(0, numberOfDays)
                .Select(offset => startDate.AddDays(offset))
                .Select(date => chartData.FirstOrDefault(x => x.Date == date) ??
                    new DailyPointsChartDTO
                    {
                        Date = date,
                        Points = 0
                    })
                .ToList();

            return new ApiResponse<List<DailyPointsChartDTO>>(
                true,
                "Chart data retrieved successfully",
                StatusCodes.Status200OK,
                completeChartData,
                new List<string>());
        }
    }
}
