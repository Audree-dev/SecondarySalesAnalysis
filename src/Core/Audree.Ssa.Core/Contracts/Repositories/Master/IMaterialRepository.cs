using Audree.Ssa.Core.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
    public interface IMaterialRepository
    {
        Task<List<Material>> GetAllAsync();
        Task<Material> GetByIdAsync(int? Id);
        Task SaveOrUpdateAsync(Material material);
        Task MaterialVerification(Material material);
        Task UpdateAsync(Material material, int? Id);
        void DeleteById(int Id);

    }
}
