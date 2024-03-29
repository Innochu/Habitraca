﻿using Microsoft.AspNetCore.Identity;

namespace Habitraca.Domain.Entities
{
    public class User : IdentityUser
    {
       
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;    
       
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateModified { get; set; }
    }
}
