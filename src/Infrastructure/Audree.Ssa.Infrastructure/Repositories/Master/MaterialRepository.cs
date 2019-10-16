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
    public class MaterialRepository : IMaterialRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _db;

        public MaterialRepository(IUnitOfWork unitOfWork, ISSADbContexts db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public Task MaterialVerification(Material material)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Material>> GetAllAsync()
        {
            using (_unitOfWork)
            {
                return await _db.Materials.ToListAsync();
            }
        }

        public async Task<Material> GetByIdAsync(int? Id)
        {
            using (_unitOfWork)
            {
                return await _db.Materials.FindAsync(Id);
            }
        }

        public async Task SaveOrUpdateAsync(Material material)
        {
            using (_unitOfWork)
            {
                await _db.Materials.AddAsync(material);
                _unitOfWork.Commit();
            }
        }
        public async Task UpdateAsync(Material material, int? Id)
        {
            using (_unitOfWork)
            {
                if (Id != null)
                {
                    _db.Materials.Update(material);
                    _db.SaveChanges();
                }
            }
        }
        public void DeleteById(int Id)
        {
            using (_unitOfWork)
            {
                var material = _db.Materials.Find(Id);
                if (material != null)
                {
                    _db.Materials.Remove(material);
                    _db.SaveChanges();
                }

            }

        }
    }
}
