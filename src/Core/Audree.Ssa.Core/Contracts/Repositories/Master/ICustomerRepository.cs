using Audree.Ssa.Core.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
   public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int? Id);
        Task SaveOrUpdateAsync(Customer customer);
        Task CustomerVerification(Customer customer);
        Task UpdateAsync(Customer customer, int? Id);
        void DeleteById(int Id);
    }
}
