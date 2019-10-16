using Audree.Ssa.Core.Model.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(int? Id);
        Task SaveOrUpdateAsync(Profile profile);
        Task ProfileVerification(Profile profile);
    }
}
