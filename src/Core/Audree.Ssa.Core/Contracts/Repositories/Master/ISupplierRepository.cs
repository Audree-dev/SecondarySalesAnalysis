using Audree.Ssa.Core.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
    public interface ISupplierRepository
    {

        Task<List<Supplier>> GetAllAsync();

        Task<Supplier> GetByIdAsync(int? Id);

        Task SaveorUpdateAsync(Supplier supplier);

        Task Supplierverification(Supplier supplier);

        Task UpdateAsync(Supplier supplier, int? Id);

        void DeleteById(int Id);
    }
}
