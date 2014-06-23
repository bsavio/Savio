using System.Data.Entity;
using Savio.Core.Data.Ef.Repository;

namespace Savio.Core.Data.Ef.Provider
{
    public interface IEfRepositoryProvider
    {
        DbContext DbContext { get; set; }
        IEfRepository<T> GetEfRepository<T>() where T : class;
    }
}
