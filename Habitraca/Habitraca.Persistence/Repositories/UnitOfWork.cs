using Habitraca.Application.Interface.Repositories;
using Habitraca.Persistence.DbContextFolder;
using Habitraca.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Habitraca.Application.Interfaces.Repositories;

namespace Habitraca.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly HabitDbContext _context;

		public UnitOfWork(HabitDbContext context)
{
    _context = context;
    UserRepository = new UserRepository(_context);
    CareerGrowthRepository = new CareerGrowthRepository(_context);
    ComputerLiteracyRepository = new ComputerLiteracyRepository(_context);
    FinancialManagementRepository = new FinancialManagementRepository(_context);
    HealthyEatingRepository = new HealthyEatingRepository(_context);
    LeadershipRepository = new LeadershipRepository(_context);
    MentalWellnessRepository = new MentalWellnessRepository(_context);
    PersonalGrowthRepository = new PersonalGrowthRepository(_context);
    PhysicalFitnessRepository = new PhysicalFitnessRepository(_context);
    PrimaryAcademicsRepository = new PrimaryAcademicsRepository(_context);
    SecondaryAcademicsRepository = new SecondaryAcademicsRepository(_context);
    SocialDevelopmentRepository = new SocialDevelopmentRepository(_context);
    SpiritualGrowthRepository = new SpiritualGrowthRepository(_context);
    TertiaryAcademicsRepository = new TertiaryAcademicsRepository(_context);
}

        public IUserRepository UserRepository { get; set; }

public ICareerGrowthRepository CareerGrowthRepository { get; set; }

public IComputerLiteracyRepository ComputerLiteracyRepository { get; set; }

public IFinancialManagementRepository FinancialManagementRepository { get; set; }

public IHealthyEatingRepository HealthyEatingRepository { get; set; }

public ILeadershipRepository LeadershipRepository { get; set; }

public IMentalWellnessRepository MentalWellnessRepository { get; set; }

public IPersonalGrowthRepository PersonalGrowthRepository { get; set; }

public IPhysicalFitnessRepository PhysicalFitnessRepository { get; set; }

public IPrimaryAcademicsRepository PrimaryAcademicsRepository { get; set; }

public ISecondaryAcademicsRepository SecondaryAcademicsRepository { get; set; }
public ISocialDevelopmentRepository SocialDevelopmentRepository { get; set; }
public ISpiritualGrowthRepository SpiritualGrowthRepository { get; set; }
public ITertiaryAcademicsRepository TertiaryAcademicsRepository { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error occurred while saving changes to the database.", ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


  //      public void Dispose()
		//{
		//	_context.Dispose();
		//}
	}
}
