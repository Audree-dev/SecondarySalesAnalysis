using Audree.Ssa.Core.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
     public interface IUOMRepository
    {
        Task<List<UOM>> GetAllAsync();
        Task<UOM> GetByIdAsync(int? Id);
        Task SaveOrUpdateAsync(UOM Uom);
        Task UOMVerification(UOM Uom);
        Task UpdateAsync(UOM uom, int? Id);
        void DeleteById(int Id);
    }
}
