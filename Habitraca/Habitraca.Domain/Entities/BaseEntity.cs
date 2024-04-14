using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Habitraca.Domain.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 

        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
