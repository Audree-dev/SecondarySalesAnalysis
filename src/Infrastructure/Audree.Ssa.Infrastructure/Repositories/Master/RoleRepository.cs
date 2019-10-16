using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audree.Ssa.Infrastructure.Repositories.Master
{
    public class RoleRepository:IRoleRepository
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ISSADbContexts _db;

        public RoleRepository( ISSADbContexts db ,IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;   
            _db = db;
        }

        public Role Create(Role role)
        {
            using (_unitofwork)
            {
                _db.roles.Add(role);
                _db.SaveChanges();
                return role;

            }



        }

        public  List<UsersInRoles> GetRolesByUserID(int userId)
        {
            using (_unitofwork)
            {
                //var role= _context.Roles.Where(w => w.Id == userId).ToList();
                var role = _db.UsersInRoleses.Where(w => w.UserId == userId).ToList();
                //  var role = _context.Roles.SingleOrDefault(x => x.UserId == userId);

                // check if username exists
                if (role == null)
                    return null;

                // authentication successful
                return role;
            }
           
        }
        public async Task<List<Role>> GetAllAsync()
        {
            using (_unitofwork)
            {
            return await _db.roles.ToListAsync();

            }
        }

        public async Task<Role> GetByIdAsync(int? Id)
        {

            using (_unitofwork)
            {
                return await _db.roles.FindAsync(Id);
            }
            
        }
        public async Task UpdateAsync(Role role, int? Id)
        {

            using (_unitofwork)
            {
                if (Id != null)
                {
                    _db.roles.Update(role);
                    _db.SaveChanges();
                }

            }
        }
        public void DeleteById(int Id)
        {
            using (_unitofwork)
            {

                var role = _db.roles.Find(Id);
                if (role != null)
                {
                    _db.roles.Remove(role);
                    _db.SaveChanges();
                }
            }

            

        }
    }
}
