
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Interface.Service
{
    public interface IGraphService
    {
        List<Graph> GetTaskDataForRange(DateTime startDate, DateTime endDate, string id);
    }
}
