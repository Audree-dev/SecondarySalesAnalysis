using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
    public class ProfilesMasterRepository : IProfilesMastersRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public ProfilesMasterRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public Task ProfileVerification(ProfilesMaster profile)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProfilesMaster>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                return await _db.ProfilesMasters.ToListAsync();
            }
        }


        public async Task<ProfilesMaster> GetByIdAsync(int? Id)
        {
            using (_unitOfWork)
            {
                return await _db.ProfilesMasters.FindAsync(Id);
            }
        }

        public async Task SaveOrUpdateAsync(ProfilesMaster profilesMaster)
        {
            using (_unitOfWork)
            {
                await _db.ProfilesMasters.AddAsync(profilesMaster);
                _unitOfWork.Commit();
            }
        }
        public async Task UpdateAsync(ProfilesMaster profilesmaster, int? Id)
        {
            using (_unitOfWork)
            {

                if (Id != null)
                {
                    _db.ProfilesMasters.Update(profilesmaster);
                    _db.SaveChanges();
                }


            }
        }
        public void DeleteById(int Id)
        {
            using (_unitOfWork)
            {
                var profilesMaster = _db.ProfilesMasters.Find(Id);
                if (profilesMaster != null)
                {
                    _db.ProfilesMasters.Remove(profilesMaster);
                    _db.SaveChanges();
                }

            }

        }
    }
}



    




    

