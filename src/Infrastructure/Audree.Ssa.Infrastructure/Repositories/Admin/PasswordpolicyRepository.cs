using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
    public class PasswordpolicyRepository : IPasswordpolicyRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ISSADbContexts _db;

        public PasswordpolicyRepository(ISSADbContexts db, IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _db = db;
        }

        public Task<bool> NocheckChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<Passwordpolicy> passwordpolicy()
        {
            return await _db.Passwordpolicies.FirstOrDefaultAsync();
        }

        public async Task SavePasswordPolicy(Passwordpolicy _passwordpolicy)
        {
            int UserId = 0;// To get User Id from session or user identity table.
            using (_UnitOfWork)
            {
                string Msg = null;
                if (_passwordpolicy.Id == 0)
                {
                    _passwordpolicy.CreatedBy = UserId;
                    _passwordpolicy.CreatedDate = DateTime.Now;
                    _passwordpolicy.Active = true;
                }
                else
                {
                    _passwordpolicy.ModifiedBy = UserId;
                    _passwordpolicy.ModifiedDate = DateTime.Now;
                }
                Msg = "Saved Successfully";

                var result = await _db.Passwordpolicies.AddAsync(_passwordpolicy);
                _UnitOfWork.Commit();
            }
        }
    }
}
