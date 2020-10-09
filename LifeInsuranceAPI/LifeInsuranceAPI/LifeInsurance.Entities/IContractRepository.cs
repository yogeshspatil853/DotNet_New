using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeInsurance.Entities
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contracts>> GetAll(string search, string sortCol, string sortDir, int? skip, int? take);
        Task<int> Create(ContractModel model);
        Task<int> Update(ContractModel model);
        Task<int> Delete(int id);
    }
}
