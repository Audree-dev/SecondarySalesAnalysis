using Audree.Ssa.Infrastructure.Data;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using System;

namespace Audree.Ssa.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ISSADbContexts _databaseContext;
        private bool _disposed = false;

       
        public UnitOfWork(ISSADbContexts databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _databaseContext != null)
            {
                _databaseContext.Dispose();
            }

            _disposed = true;
        }
    }
}
