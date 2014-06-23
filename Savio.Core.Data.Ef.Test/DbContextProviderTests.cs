using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Savio.Core.Data.Ef.Test
{
    [TestClass]
    public class DbContextProviderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DbContextProvider_CTor_NullThrowsArgumentNullException()
        {
// ReSharper disable once UnusedVariable
            var dbContextProvider = new DbContextProvider<Object>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DbContextProvider_CTor_EmptyStringThrowsArgumentNullException()
        {
// ReSharper disable once UnusedVariable
            var dbContextProvider = new DbContextProvider<Object>(String.Empty);
        }
    }
}
