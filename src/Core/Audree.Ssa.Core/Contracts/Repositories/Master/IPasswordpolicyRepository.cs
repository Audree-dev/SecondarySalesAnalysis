using Audree.Ssa.Core.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Master
{
    public interface IPasswordpolicyRepository
    {
        Task<bool> NocheckChanges();
        Task<Passwordpolicy> passwordpolicy();
        Task SavePasswordPolicy(Passwordpolicy _passwordpolicy);
    }
}
