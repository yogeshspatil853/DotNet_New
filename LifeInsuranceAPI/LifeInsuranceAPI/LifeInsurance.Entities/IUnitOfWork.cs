using System;

namespace LifeInsurance.Entities
{
    public  interface IUnitOfWork:IDisposable
    {
        IContractRepository Contracts { get; }
        ICoveragePlansRepository CoveragePlans { get; }
        public IRateChartRepository RateChart { get; }
        int Complete();
    }
}
