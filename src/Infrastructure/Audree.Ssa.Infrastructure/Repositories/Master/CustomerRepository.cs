using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audree.Ssa.Infrastructure.Repositories.Master
{
   public class CustomerRepository:ICustomerRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public CustomerRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        public Task CustomerVerification(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                return await _db.customers.ToListAsync();
            }
        }

        public async Task<Customer> GetByIdAsync(int? Id)
        {
            using (_unitOfWork)
            {
                return await _db.customers.FindAsync(Id);
            }
        }

        public async Task SaveOrUpdateAsync(Customer customer)
        {
            using (_unitOfWork)
            {
                await _db.customers.AddAsync(customer);
                _unitOfWork.Commit();
            }
        }
        public async Task UpdateAsync(Customer customer, int? Id)
        {
            using (_unitOfWork)
            {
                if (Id != null)
                {
                    _db.customers.Update(customer);
                    _db.SaveChanges();
                }
            }
        }
        public void DeleteById(int Id)
        {
            using (_unitOfWork)
            {
                var customer = _db.customers.Find(Id);
                if (customer != null)
                {
                    _db.customers.Remove(customer);
                    _db.SaveChanges();
                }

            }

        }
    }
}
