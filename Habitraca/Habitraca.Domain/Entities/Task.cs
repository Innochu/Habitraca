using Microsoft.AspNetCore.Identity;

namespace Habitraca.Domain.Entities
{
    public class PrimaryAcademics : BaseEntity
    {
        public string Name {get; set;} = string.Empty; 
        public string Points {get; set;}= string.Empty;
    }
     public class SecondaryAcademics : BaseEntity
    {
        public string Name {get; set;} = string.Empty; 
        public string Points {get; set;}= string.Empty;
    }
     public class TertiaryAcademics : BaseEntity
    {
        public string Name {get; set;} = string.Empty; 
        public string Points {get; set;}= string.Empty;
    }
} 