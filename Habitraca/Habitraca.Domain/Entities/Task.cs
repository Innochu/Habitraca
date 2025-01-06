using Habitraca.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Habitraca.Domain.Entities
{
    public class HabitTask : BaseEntity
    {
      public string Title { get; set; } = string.Empty;
        public int Points { get; set; } 
        public bool IsActive { get; set; } = true;
        public TaskCategory Category { get; set; }
        public TaskFrequency Frequency { get; set; }
        
        // Foreign key for user
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
    }

     public class TaskCompletion : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid TaskId { get; set; }
        public HabitTask Task { get; set; }
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    }

}
