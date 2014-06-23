using System;
using System.Data.Entity;
using System.Linq;

namespace Savio.Core.Data.Ef.Repository
{
    public class EfRepository<T> : IEfReadOnlyRepository<T>, IEfRepository<T> where T : class
    {
        public EfRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public DbContext DbContext { get; private set; }
        public IDbSet<T> DbSet { get; private set; }

        public virtual IQueryable<T> Get()
        {
            return DbSet;
        }

        public virtual T Get(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual IQueryable<T> Filter(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public virtual void Add(T t)
        {
            DbSet.Add(t);
        }

        public virtual void Update(T t)
        {
            DbSet.Attach(t);
            var entity = DbContext.Entry(t);
            entity.State = EntityState.Modified;
        }

        public virtual void Delete(T t)
        {
            DbSet.Remove(t);
        }

        public virtual void Delete(params object[] keys)
        {
            Delete(Get(keys));
        }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
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
            DbContext.Dispose();
            DbContext = null;
            DbSet = null;
        }

        #endregion
    }
}
