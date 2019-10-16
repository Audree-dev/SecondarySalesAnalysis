using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audree.Ssa.Infrastructure.Repositories.Master
{
   public class ReasonForRejectionRepository: IReasonForRejectionRepository
    {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ISSADbContexts _db;

            public ReasonForRejectionRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
            {
                _unitOfWork = unitOfWork;
                _db = db;
            }

            public async Task<List<ReasonForRejection>> GetAllAsync()
            {
                using (_unitOfWork)
                {
                    return await _db.ReasonForRejections.ToListAsync();
                }
            }

            public async Task<ReasonForRejection> GetByIdAsync(int? id)
            {
                using (_unitOfWork)
                {
                    return await _db.ReasonForRejections.FindAsync(id);
                }
            }

            public async Task SaveOrUpdateAsync(ReasonForRejection rejection)
            {
                using (_unitOfWork)
                {

                    await _db.ReasonForRejections.AddAsync(rejection);
                    _unitOfWork.Commit();
                }
            }

            public async Task UpdateAsync(ReasonForRejection rejection, int? id)
            {
                using (_unitOfWork)
                {

                    if (id != null)
                    {
                        _db.ReasonForRejections.Update(rejection);
                        _db.SaveChanges();
                    }


                }
            }
            public void DeleteById(int? id)
            {
                using (_unitOfWork)
                {
                    var rejection = _db.ReasonForRejections.Find(id);
                    if (rejection != null)
                    {
                        _db.ReasonForRejections.Remove(rejection);
                        _db.SaveChanges();
                    }
                }
            }

      
    }
}
