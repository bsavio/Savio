using System;
using System.Data.Entity;

namespace Savio.Core.Data.Ef
{
    public class DbContextProvider<T> : IDbContextProvider<T> where T : class
    {
        public DbContextProvider(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            
            DbContext = new DbContext(connectionString);
            DbSet = DbContext.Set<T>();

        }

        public DbContext DbContext { get; private set; }
        public IDbSet<T> DbSet { get; private set; }

        public virtual void Dispose()
        {
            DbContext.Dispose();
            DbSet = null;
            DbContext = null;
            GC.SuppressFinalize(this);
        }
    }
}
