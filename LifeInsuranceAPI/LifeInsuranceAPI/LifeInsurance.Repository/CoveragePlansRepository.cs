using LifeInsurance.Entities;

namespace LifeInsurance.Repository
{
    internal class CoveragePlansRepository : GenericRepository<CoveragePlans>, ICoveragePlansRepository
    {
        public CoveragePlansRepository(LifeInsuranceDbContext context) : base(context)
        {
        }
    }
}