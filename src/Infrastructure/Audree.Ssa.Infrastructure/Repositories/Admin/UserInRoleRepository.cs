using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
     public class UserInRoleRepository:IUserInRoleRepository
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public UserInRoleRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        public  async Task<List<UsersInRoles>> GetUserInRolesByID(int userId)
        {
            using (_unitOfWork)
            {
                var role =  await _db.roles.Where(w => w.Id == userId).ToListAsync();
                //  var role = _context.Roles.SingleOrDefault(x => x.UserId == userId);

                // check if username exists
                if (role == null)
                    return null;

                // authentication successful
                return null;
            }
           
        }
        public UsersInRoles Create(UsersInRoles usersInRoles)
        {
            using (_unitOfWork)
            {
                _db.UsersInRoleses.Add(usersInRoles);
                _db.SaveChanges();
                return usersInRoles;
            }
         
        }
    }
}
