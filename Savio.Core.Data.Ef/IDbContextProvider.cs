using System;
using System.Data.Entity;

namespace Savio.Core.Data.Ef
{
    public interface IDbContextProvider<T> : IDisposable where T : class
    {
        DbContext DbContext { get; }
        IDbSet<T> DbSet { get; }
    }
}