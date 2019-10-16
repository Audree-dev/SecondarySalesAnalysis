using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Model.Admin;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
    public interface IUserInRoleRepository
    {
        Task<List<UsersInRoles>> GetUserInRolesByID(int userId);
        UsersInRoles Create(UsersInRoles usersInRoles);
    }
}
