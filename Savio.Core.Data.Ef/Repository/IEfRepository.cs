using Savio.Core.Data.Ef.Provider;

namespace Savio.Core.Data.Ef.Repository
{
    public interface IEfRepository<T> : IDbContextProvider<T>,IRepository<T> where T : class
    {
        
    }
}