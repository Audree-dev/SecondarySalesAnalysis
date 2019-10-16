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
    public class SupplierRepository : ISupplierRepository
    {
        private IUnitOfWork _unitOfWork;
        private ISSADbContexts _db;

        public SupplierRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;

        }

        public Task Supplierverification(Supplier supplier)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Supplier>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                return await _db.Suppliers.ToListAsync();
            }
        }


        public async Task<Supplier> GetByIdAsync(int? Id)
        {
            using (_unitOfWork)
            {
                return await _db.Suppliers.FindAsync(Id);
            }
        }

        public async Task SaveorUpdateAsync(Supplier supplier)
        {
            using (_unitOfWork)
            {
               await _db.Suppliers.AddAsync(supplier);
                _unitOfWork.Commit();
            }
        }


     public async Task UpdateAsync(Supplier supplier,int? Id)
        {
            using (_unitOfWork)
            {
                if(Id!= null)
                {
                    _db.Suppliers.Update(supplier);
                    _db.SaveChanges();
                }
            }

        }

        public void DeleteById(int Id)
        {
            using (_unitOfWork)
            {
                var supplier = _db.Suppliers.Find(Id);
                    if(supplier!=null)
                {
                    _db.Suppliers.Remove(supplier);
                    _db.SaveChanges();
                }
            }
        }

    }



}
