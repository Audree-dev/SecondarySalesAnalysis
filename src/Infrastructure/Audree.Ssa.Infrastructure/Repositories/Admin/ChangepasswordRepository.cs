using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
    public class ChangepasswordRepository : IChangepasswordRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ISSADbContexts _db;

        public ChangepasswordRepository(ISSADbContexts db, IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _db = db;
        }

        public async Task<Changepassword> changepassword()
        {
            return await _db.Changepasswords.FindAsync();
        }
       
        public async Task SaveChangepassword(Changepassword _changepassword)
        {
            int LoginId = 0;// To get User Id from session or user identity table.
            
            using (_UnitOfWork)
            {
                string Msg = null;
                
                if (_changepassword.LoginId == LoginId)
                {
                    _changepassword.CreatedBy = LoginId;
                    _changepassword.CreatedDate = DateTime.Now;
                }
                else
                {
                    _changepassword.ModifiedBy = LoginId;
                    _changepassword.ModifiedDate = DateTime.Now;
                }
                Msg = "Saved Successfully";

                var result = await _db.Changepasswords.AddAsync(_changepassword);
                _UnitOfWork.Commit();
            }
        }
    }
}
