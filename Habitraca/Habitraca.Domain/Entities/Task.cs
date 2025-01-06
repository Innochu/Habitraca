using Microsoft.AspNetCore.Identity;

namespace Habitraca.Domain.Entities
{
    public class PrimaryAcademics : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class SecondaryAcademics : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class TertiaryAcademics : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class CareerGrowth : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class PhysicalFitness : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class MentalWellness : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class Leadership : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class FinancialManagement : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class SocialDevelopment : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class PersonalGrowth : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class SpiritualGrowth : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class HealthyEating : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class ComputerLiteracy : BaseEntity
    {
        public string Task { get; set; } = string.Empty; 
        public string Points { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
