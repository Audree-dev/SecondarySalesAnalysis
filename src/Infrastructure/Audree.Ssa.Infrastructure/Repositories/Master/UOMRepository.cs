using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.Data;
using Audree.Ssa.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Infrastructure.Repositories.Master
{
   public  class UOMRepository : IUOMRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ISSADbContexts _db;

        public UOMRepository(IUnitOfWork unitOfWork,ISSADbContexts db)
        {
            _UnitOfWork = unitOfWork;
            _db = db;
        }
        public Task UOMVerification(UOM Uom)
        {
            throw new NotImplementedException();
        }
        public async Task<List<UOM>>GetAllAsync()
        {
            using(_UnitOfWork)
            {
                return await _db.UOMs.ToListAsync();
            }
        }
        public async Task<UOM>GetByIdAsync(int? Id)
        {
            using(_UnitOfWork)
            {
                return await _db.UOMs.FindAsync(Id);
            }
        }
        public async Task SaveOrUpdateAsync(UOM Uom)
        {
            using(_UnitOfWork)
            {
                await _db.UOMs.AddAsync(Uom);
                _UnitOfWork.Commit();
            }
        }
        public async Task UpdateAsync(UOM uom, int? Id)
        {
            using (_UnitOfWork)
            {

                if (Id != null)
                {
                    _db.UOMs.Update(uom);
                    _db.SaveChanges();
                }


            }
        }
        public void DeleteById(int Id)
        {
            using (_UnitOfWork)
            {
                var uom = _db.Countries.Find(Id);
                if (uom != null)
                {
                    _db.Countries.Remove(uom);
                    _db.SaveChanges();
                }

            }

        }

    }
}
