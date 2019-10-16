using Audree.Ssa.Infrastructure.Data;
using Audree.Ssa.Core.Contracts;
using Audree.Ssa.Core.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.ViewModel;
using AutoMapper;

namespace Audree.Ssa.Infrastructure.Repositories.Master
{
    public class CountryRepository:ICountryRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public CountryRepository(IUnitOfWork unitOfWork,ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

       
        public Task CountryVerification(Country country)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                
                return await _db.Countries.ToListAsync();
            }
        }

        public async Task<Country> GetByIdAsync(int? Id)
        {
            using (_unitOfWork)
            {
                return await _db.Countries.FindAsync(Id);
            }
        }

        public async Task SaveOrUpdateAsync(Country country)
        {
            using (_unitOfWork)
            {
                
                await _db.Countries.AddAsync(country);
                _unitOfWork.Commit();
            }
        }

        public async Task UpdateAsync(Country country,int? Id)
        {
            using (_unitOfWork)
            {
            
                if (Id != null)
                {
                    _db.Countries.Update(country);
                    _db.SaveChanges();
                }
              
                
            }
        }
        public void DeleteById(int Id)
        {
            using(_unitOfWork)
            {
                var country = _db.Countries.Find(Id);
                if (country != null)
                {
                     _db.Countries.Remove(country);
                  _db.SaveChanges();
                }

            }

        }
    }
}
