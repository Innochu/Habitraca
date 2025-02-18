using Habitraca.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Habitraca.Domain.Entities
{
    public class TaskDto
        {
        public string Task { get; set; }
           public int Points { get; set; }
            public TaskFrequency Frequency { get; set; }
            public TaskCategory Category { get; set; }
        }
    public class CompletedTaskDto
    {
        public string TaskId { get; set; }
        public string UserId { get; set; }
        public DateTime CompletedAt { get; set; }
        public string TaskTitle { get; set; } 
        public int TaskPoints { get; set; }
    }
    public class DailyPointsChartDTO
    {
        public DateTime Date { get; set; }
        public int Points { get; set; }
    }
}
