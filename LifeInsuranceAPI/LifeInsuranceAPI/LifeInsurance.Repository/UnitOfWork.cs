using LifeInsurance.Entities;
using System;
namespace LifeInsurance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LifeInsuranceDbContext _context;
        public IContractRepository Contracts { get; }
        public ICoveragePlansRepository CoveragePlans  { get; }
        public IRateChartRepository RateChart { get; }

        public UnitOfWork(LifeInsuranceDbContext lifeInsuranceDbContext)
        {
            this._context = lifeInsuranceDbContext;
            this.Contracts = new ContractRepository(_context);
            this.CoveragePlans = new CoveragePlansRepository(_context);
            this.RateChart = new RateChartRepository(_context);
      
    }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
