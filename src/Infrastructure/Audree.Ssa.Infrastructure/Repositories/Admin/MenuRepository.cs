using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
   public class MenuRepository:IMenuRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public MenuRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        public async Task<List<Menu>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                return await _db.menus.ToListAsync();
            }
        }
    }
}
