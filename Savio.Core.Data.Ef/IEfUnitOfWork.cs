using Savio.Core.Data.Ef.Repository;

namespace Savio.Core.Data.Ef
{
    public interface IEfUnitOfWork
    {
        IEfRepository<T> GetEfRepository<T>() where T : class;
        void Commit();
    }
}
