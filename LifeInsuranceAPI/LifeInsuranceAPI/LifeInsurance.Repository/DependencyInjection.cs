using LifeInsurance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LifeInsurance.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IContractRepository, ContractRepository>();
         services.AddTransient<ICoveragePlansRepository, CoveragePlansRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<LifeInsuranceDbContext>(opt => opt
                .UseSqlServer("Data Source=173.248.132.189,1533;Initial Catalog=LifeInsuranceDB;User ID=sa;Password=N@d@MoniZ$3;"));
            return services;
        }
    }
}
