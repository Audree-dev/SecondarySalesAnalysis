using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
    public interface IProfilesMastersRepository
    {


        Task<IEnumerable<ProfilesMaster>> GetAllAsync();
        Task<ProfilesMaster> GetByIdAsync(int? Id);
        Task SaveOrUpdateAsync(ProfilesMaster profilesmaster);
        Task ProfileVerification(ProfilesMaster profilesmaster);
        Task UpdateAsync(ProfilesMaster profilesmaster, int? Id);
        void DeleteById(int Id);
    }
}
