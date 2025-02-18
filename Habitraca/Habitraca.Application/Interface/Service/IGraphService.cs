
using Habitraca.Domain;
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Interface.Service
{
    public interface IGraphService
    {
        Task<ApiResponse<List<DailyPointsChartDTO>>> GetDailyPointsChartData(string id, int numberOfDays = 7);
    }
}
