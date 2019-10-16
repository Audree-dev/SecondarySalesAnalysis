using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int? Id);
        Task SaveOrUpdateAsync(Country country);
        Task CountryVerification(Country country);
        Task UpdateAsync(Country country,int? Id);
         void  DeleteById(int Id);
        
    }
}
