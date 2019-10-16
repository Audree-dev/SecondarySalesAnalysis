using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Infrastructure.Repositories.Master
{

    public class SalutationRepository : ISalutationRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public SalutationRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public Task SalutationVerification(Salutation salutation)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Salutation>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                return await _db.salutations.ToListAsync();
            }
        }

        public async Task<Salutation> GetByIdAsync(int? Id)
        {
            using (_unitOfWork)
            {
                return await _db.salutations.FindAsync(Id);
            }
        }

        public async Task SaveOrUpdateAsync(Salutation salutation)
        {
            using (_unitOfWork)
            {
                await _db.salutations.AddAsync(salutation);
                _unitOfWork.Commit();
            }
        }
        public async Task UpdateAsync(Salutation salutation, int? Id)
        {
            using (_unitOfWork)
            {
                if (Id != null)
                {
                    _db.salutations.Update(salutation);
                    _db.SaveChanges();
                }
            }
        }
        public void DeleteById(int Id)
        {
            using (_unitOfWork)
            {
                var salutation = _db.salutations.Find(Id);
                if (salutation != null)
                {
                    _db.salutations.Remove(salutation);
                    _db.SaveChanges();
                }

            }

        }
    }
}
