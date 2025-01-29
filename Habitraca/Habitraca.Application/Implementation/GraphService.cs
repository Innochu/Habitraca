
using Habitraca.Application.Interface.Service;
using Habitraca.Domain.Entities;

namespace Habitraca.Application.Implementation
{
    public class GraphService : IGraphService
    {
        public GraphService()
        {
            
        }

        public List<Graph> GetTaskDataForRange(DateTime startDate, DateTime endDate, string id)
        {
            if ((endDate - startDate).Days > 30)
            {
                throw new ArgumentException("The date range cannot be more than 30 days.");
            }

            var random = new Random();
            var taskDataList = new List<Graph>();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                taskDataList.Add(new Graph
                {
                    Date = date,
                    TaskCount = random.Next(1, 10)
                });
            }

            return taskDataList;
        }
    }
}
