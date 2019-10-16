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
    public class ProfileRepository : IProfileRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContext _db;

        public ProfileRepository(IUnitOfWork unitOfWork, ISSADbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public Task ProfileVerification(Profile profile)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                return await _db.profiles.ToListAsync();
            }
        }

        public async Task<Profile> GetByIdAsync(int? Id)
        {
            using (_unitOfWork)
            {
                return await _db.profiles.FindAsync(Id);
            }
        }

        public async Task SaveOrUpdateAsync(Profile profile)
        {
            using (_unitOfWork)
            {
                await _db.profiles.AddAsync(profile);
                _unitOfWork.Commit();
            }
        }


    }
}



    



