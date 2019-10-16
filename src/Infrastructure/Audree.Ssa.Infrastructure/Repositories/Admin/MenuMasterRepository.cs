using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
     public class MenuMasterRepository:IMenuMasterRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public MenuMasterRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        public   async  Task<MenuMaster> Create(MenuMaster menuMaster)
        {
            using (_unitOfWork)
            {
               await _db.MenuMasters.AddAsync(menuMaster);
                _db.SaveChanges();
                return menuMaster;
            }
          
        }

        public async  Task<List<MenuMaster>> GetMenuByUserID(int ? userId)
        {
            using (_unitOfWork)
            {
                var menu =  await _db.MenuMasters.Where(w => w.Id == userId).ToListAsync();
                //  var role = _context.Roles.SingleOrDefault(x => x.UserId == userId);

                // check if username exists
                if (menu == null)
                    return null;

                // authentication successful
                return menu;
            }
            
          
        }

        public async Task<List<MenuMaster>> GetAllAsync()
        {
            return await _db.MenuMasters.ToListAsync();
        }
    }
}
