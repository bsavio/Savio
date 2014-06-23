using System;
using System.Data.Entity;
using System.Linq;

namespace Savio.Core.Data.Ef
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private IDbContextProvider<T> _dbContextProvider;

        public EfRepository(IDbContextProvider<T> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public virtual IQueryable<T> Get()
        {
            return _dbContextProvider.DbSet;
        }

        public virtual T Get(params object[] keys)
        {
            return _dbContextProvider.DbSet.Find(keys);
        }

        public virtual IQueryable<T> Filter(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbContextProvider.DbSet.Where(expression);
        }

        public virtual void Add(T t)
        {
            _dbContextProvider.DbSet.Add(t);
        }

        public virtual void Update(T t)
        {
            _dbContextProvider.DbSet.Attach(t);
            var entity = _dbContextProvider.DbContext.Entry(t);
            entity.State = EntityState.Modified;
        }

        public virtual void Delete(T t)
        {
            _dbContextProvider
                .DbSet
                .Remove(t);
        }

        public virtual void Delete(params object[] keys)
        {
            Delete(Get(keys));
        }

        public virtual void Commit()
        {
            _dbContextProvider
                .DbContext
                .SaveChanges();
        }

        public virtual void Dispose()
        {
            _dbContextProvider.Dispose();
            _dbContextProvider = null;
            GC.SuppressFinalize(this);
        }
    }
}
