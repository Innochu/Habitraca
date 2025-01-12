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
      
    }
}
