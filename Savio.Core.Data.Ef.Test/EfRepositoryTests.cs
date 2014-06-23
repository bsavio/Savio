using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Savio.Core.Data.Ef.Test
{
    [TestClass]
    public class EfRepositoryTests
    {
        [TestMethod]
        public void EfRepository_Dispose_CallsDisposeOnDbContextProvider()
        {
            var mockDbContextProvider = new Mock<IDbContextProvider<Object>>();
            var efRepository = new EfRepository<Object>(mockDbContextProvider.Object);
            efRepository.Dispose();
            mockDbContextProvider.Verify(m => m.Dispose());
        }
    }
}
