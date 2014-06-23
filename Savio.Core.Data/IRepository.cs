using System;
using System.Linq;
using System.Linq.Expressions;

namespace Savio.Core.Data
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> Get();
        T Get(params object[] keys);
        IQueryable<T> Filter(Expression<Func<T, bool>> expression);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        void Delete(params object[] keys);
        void Commit();
    }
}
