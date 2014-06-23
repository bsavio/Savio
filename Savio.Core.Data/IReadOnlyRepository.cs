using System;
using System.Linq;
using System.Linq.Expressions;

namespace Savio.Core.Data
{
    public interface IReadOnlyRepository<T>
    {
        IQueryable<T> Get();
        T Get(params object[] keys);
        IQueryable<T> Filter(Expression<Func<T, bool>> expression);
    }
}