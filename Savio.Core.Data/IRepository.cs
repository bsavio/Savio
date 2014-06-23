using System;

namespace Savio.Core.Data
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IDisposable
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        void Delete(params object[] keys);
        void Commit();
    }
}
