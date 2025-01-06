using Habitraca.Domain.Entities;
using Habitraca.Application.Interfaces.Repositories;

namespace Habitraca.Application.Interface.Repositories
{
    public interface IHealthyEatingRepository : IGenericRepository<HealthyEating>
    {
        Task DeleteUser(HealthyEating task);
        Task<HealthyEating> GetUserByIdAsync(string id);
        Task<HealthyEating> UpdateAsync(HealthyEating task);
    }
    public interface IPrimaryAcademicsRepository : IGenericRepository<PrimaryAcademics>
    {
        Task DeleteUser(PrimaryAcademics task);
        Task<PrimaryAcademics> GetUserByIdAsync(string id);
        Task<PrimaryAcademics> UpdateAsync(PrimaryAcademics task);
    }
    public interface ISecondaryAcademicsRepository : IGenericRepository<SecondaryAcademics>
    {
        Task DeleteUser(SecondaryAcademics task);
        Task<SecondaryAcademics> GetUserByIdAsync(string id);
        Task<SecondaryAcademics> UpdateAsync(SecondaryAcademics task);
    }
    public interface ITertiaryAcademicsRepository : IGenericRepository<TertiaryAcademics>
    {
        Task DeleteUser(TertiaryAcademics task);
        Task<TertiaryAcademics> GetUserByIdAsync(string id);
        Task<TertiaryAcademics> UpdateAsync(TertiaryAcademics task);
    }
    public interface ICareerGrowthRepository : IGenericRepository<CareerGrowth>
    {
        Task DeleteUser(CareerGrowth task);
        Task<CareerGrowth> GetUserByIdAsync(string id);
        Task<CareerGrowth> UpdateAsync(CareerGrowth task);
    }
    public interface IPhysicalFitnessRepository : IGenericRepository<PhysicalFitness>
    {
        Task DeleteUser(PhysicalFitness task);
        Task<PhysicalFitness> GetUserByIdAsync(string id);
        Task<PhysicalFitness> UpdateAsync(PhysicalFitness task);
    }
    public interface IMentalWellnessRepository : IGenericRepository<MentalWellness>
    {
        Task DeleteUser(MentalWellness task);
        Task<MentalWellness> GetUserByIdAsync(string id);
        Task<MentalWellness> UpdateAsync(MentalWellness task);
    }
    public interface ILeadershipRepository : IGenericRepository<Leadership>
    {
        Task DeleteUser(Leadership task);
        Task<Leadership> GetUserByIdAsync(string id);
        Task<Leadership> UpdateAsync(Leadership task);
    }
    public interface IFinancialManagementRepository : IGenericRepository<FinancialManagement>
    {
        Task DeleteUser(FinancialManagement task);
        Task<FinancialManagement> GetUserByIdAsync(string id);
        Task<FinancialManagement> UpdateAsync(FinancialManagement task);
    }
    public interface ISocialDevelopmentRepository : IGenericRepository<SocialDevelopment>
    {
        Task DeleteUser(SocialDevelopment task);
        Task<SocialDevelopment> GetUserByIdAsync(string id);
        Task<SocialDevelopment> UpdateAsync(SocialDevelopment task);
    }
    public interface IPersonalGrowthRepository : IGenericRepository<PersonalGrowth>
    {
        Task DeleteUser(PersonalGrowth task);
        Task<PersonalGrowth> GetUserByIdAsync(string id);
        Task<PersonalGrowth> UpdateAsync(PersonalGrowth task);
    }
     public interface ISpiritualGrowthRepository : IGenericRepository<SpiritualGrowth>
    {
        Task DeleteUser(SpiritualGrowth task);
        Task<SpiritualGrowth> GetUserByIdAsync(string id);
        Task<SpiritualGrowth> UpdateAsync(SpiritualGrowth task);
    }
     public interface IComputerLiteracyRepository : IGenericRepository<ComputerLiteracy>
    {
        Task DeleteUser(ComputerLiteracy task);
        Task<ComputerLiteracy> GetUserByIdAsync(string id);
        Task<ComputerLiteracy> UpdateAsync(ComputerLiteracy task);
    }
}
