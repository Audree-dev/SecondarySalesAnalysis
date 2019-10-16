using Audree.Ssa.Core.Model.Master;
using System.Collections.Generic;
using System.Threading.Tasks;
using Audree.Ssa.Core.Model.Admin;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        List<UsersInRoles> GetRolesByUserID(int userId);
        Role Create(Role role);
        Task UpdateAsync(Role role, int? Id);
        void DeleteById(int Id);
        Task<Role> GetByIdAsync(int? Id);

    }
}
