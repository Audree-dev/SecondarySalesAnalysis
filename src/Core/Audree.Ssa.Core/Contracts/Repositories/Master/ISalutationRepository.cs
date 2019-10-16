using Audree.Ssa.Core.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
    public interface ISalutationRepository
    {


        Task<List<Salutation>> GetAllAsync();
        Task<Salutation> GetByIdAsync(int? Id);
        Task SaveOrUpdateAsync(Salutation salutation);
        Task SalutationVerification(Salutation salutation);
        Task UpdateAsync(Salutation salutation, int? Id);
        void DeleteById(int Id);
    }
}