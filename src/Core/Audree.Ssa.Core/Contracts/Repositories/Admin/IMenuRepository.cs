using Audree.Ssa.Core.Model.Master;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
       // Task<Menu> GetByIdAsync(int? Id);
         //Task SaveOrUpdateAsync(Menu menu);
      // Task MenuVerification(Menu menu);
    }
}
