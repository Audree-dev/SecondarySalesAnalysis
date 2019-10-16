using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Model.Master;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
    public interface IReasonForRejectionRepository
    {
        Task<List<ReasonForRejection>> GetAllAsync();
        Task<ReasonForRejection> GetByIdAsync(int? id);
        Task SaveOrUpdateAsync(ReasonForRejection rejection);
        Task UpdateAsync(ReasonForRejection rejection, int? id);
        void DeleteById(int? id);
    }
}
