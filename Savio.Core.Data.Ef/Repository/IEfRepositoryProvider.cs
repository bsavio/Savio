using System.Data.Entity;

namespace Savio.Core.Data.Ef.Repository
{
    public interface IEfRepositoryProvider
    {
        DbContext DbContext { get; set; }
        IEfRepository<T> GetEfRepository<T>() where T : class;
    }
}
