using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Model.Admin;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
   public  interface ISubmenuRepository
    {
        List<Submenu> GetSubmenuByRoleID(int roleId);
        Submenu Create(Submenu submenu);
    }
}
