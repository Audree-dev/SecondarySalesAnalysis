using Audree.Ssa.Core.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
     public interface IChangepasswordRepository
    {
        
        Task<Changepassword> changepassword();
        Task SaveChangepassword(Changepassword _changepassword);
    }
}
