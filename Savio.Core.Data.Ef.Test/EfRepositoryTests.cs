using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Savio.Core.Data.Ef.Repository;

namespace Savio.Core.Data.Ef.Test
{
    [TestClass]
    public class EfRepositoryTests
    {
        [TestMethod]
        public void EfRepository_Dispose_ReleasesDbContext()
        {
            var mockDbContext = new Mock<DbContext>();
            var efRepository = new EfRepository<Object>(mockDbContext.Object);
            efRepository.Dispose();
            Assert.IsNull(efRepository.DbContext);
            Assert.IsNull(efRepository.DbSet);
        }
    }
}
