using Habitraca.Application.Interface.Repositories;

namespace Habitraca.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
	{
      IUserRepository UserRepository { get; }
        ICareerGrowthRepository CareerGrowthRepository { get; }
        IComputerLiteracyRepository ComputerLiteracyRepository { get; }
        IFinancialManagementRepository FinancialManagementRepository { get; }
        IHealthyEatingRepository HealthyEatingRepository { get; }
        ILeadershipRepository LeadershipRepository { get; }
        IMentalWellnessRepository MentalWellnessRepository { get; }
        IPersonalGrowthRepository PersonalGrowthRepository { get; }
        IPhysicalFitnessRepository PhysicalFitnessRepository { get; }
        IPrimaryAcademicsRepository PrimaryAcademicsRepository { get; }
        ISecondaryAcademicsRepository SecondaryAcademicsRepository { get; }
        ISocialDevelopmentRepository SocialDevelopmentRepository { get; }
        ISpiritualGrowthRepository SpiritualGrowthRepository { get; }
        ITertiaryAcademicsRepository TertiaryAcademicsRepository { get; }
        Task<int> SaveChangesAsync();
	}
}
