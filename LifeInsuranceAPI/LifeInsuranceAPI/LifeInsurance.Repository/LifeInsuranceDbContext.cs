using LifeInsurance.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeInsurance.Repository
{
    public class LifeInsuranceDbContext  : DbContext
    {
       public LifeInsuranceDbContext(DbContextOptions<LifeInsuranceDbContext> options) : base(options)
        { }
       public DbSet<Contracts> Contracts { get; set; }
       public DbSet<CoveragePlans> CoveragePlans { get; set; }
       public DbSet<RateChart> RateChart  { get; set; }
    }
}
