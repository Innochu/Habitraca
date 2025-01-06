using Microsoft.AspNetCore.Identity;
using System;

namespace Habitraca.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        // public string DailyTaskDone { get; set; } = string.Empty;
        // public string WeeklyTaskDone { get; set; } = string.Empty;
        // public string MonthlyTaskDone { get; set; } = string.Empty;
        // public string DailyTaskAssigned { get; set; } = string.Empty;
        // public string WeeklyTaskAssigned { get; set; } = string.Empty;
        // public string MonthlyTaskAssigned { get; set; } = string.Empty;
        public ICollection<HabitTask> Tasks { get; set; }
        public ICollection<TaskCompletion> CompletedTasks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;


        public string PasswordResetToken { get; set; } = string.Empty;
        public DateTime ResetTokenExpires { get; set; } = DateTime.UtcNow;

        public string ImageUrl { get; set; } = string.Empty;


        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}
