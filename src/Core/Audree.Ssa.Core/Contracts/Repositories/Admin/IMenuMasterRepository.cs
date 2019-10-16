using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Model.Admin;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
    public interface IMenuMasterRepository
    {
        Task<List<MenuMaster>> GetAllAsync();
        Task<List<MenuMaster>> GetMenuByUserID(int ? userId);
        Task<MenuMaster> Create(MenuMaster menuMaster);
    }
}
