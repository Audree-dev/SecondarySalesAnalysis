using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.UnitOfWork
{
   public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
