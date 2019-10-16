using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Data;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
     public class SubmenuRepository:ISubmenuRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public SubmenuRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        public Submenu Create(Submenu submenu)
        {
            using (_unitOfWork)
            {
                _db.Submenus.Add(submenu);
                _db.SaveChanges();
                return submenu;
            }
           
        }

        public List<Submenu> GetSubmenuByRoleID(int roleId)
        {
            using (_unitOfWork)
            {
                var submenu = _db.Submenus.Where(w => w.Id == roleId).ToList();
                if (submenu == null)
                    return null;
                return submenu;

            }
          
        }
    }
}
