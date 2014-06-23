using System;
using System.Data.Entity;
using Savio.Core.Data.Ef.Provider;
using Savio.Core.Data.Ef.Repository;

namespace Savio.Core.Data.Ef
{
    public class EfUnitOfWork : IEfUnitOfWork, IDisposable
    {
        private readonly IEfRepositoryProvider _efRepositoryProvider;
        private DbContext _dbContext;

        public EfUnitOfWork(DbContext dbContext, IEfRepositoryProvider efRepositoryProvider)
        {
            _dbContext = dbContext;
            _efRepositoryProvider = efRepositoryProvider;
            _efRepositoryProvider.DbContext = dbContext;
        }

        public IEfRepository<T> GetEfRepository<T>() where T : class
        {
            return _efRepositoryProvider.GetEfRepository<T>();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _efRepositoryProvider.DbContext = null;
                _dbContext = null;
            }
        }

        #endregion
    }
}
