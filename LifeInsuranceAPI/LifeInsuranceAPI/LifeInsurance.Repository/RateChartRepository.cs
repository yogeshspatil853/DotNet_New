using LifeInsurance.Entities;

namespace LifeInsurance.Repository
{
    public class RateChartRepository : GenericRepository<RateChart>, IRateChartRepository
    {
        public RateChartRepository(LifeInsuranceDbContext context) : base(context)
        {
        }
    }
}
