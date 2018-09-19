using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace PersistenceTests.PersistenceServiceTests
{
    [TestClass]
    [Ignore]
    public class LoadTests
    {
        [TestMethod]
        public void PathDoesNotExist_InvalidOperationException()
        {
            //arrange
            PersistenceService persistenceService = new PersistenceService();

            //assert
            Assert.ThrowsException<InvalidOperationException>(() => persistenceService.Load("invalidPath"));
        }
    }
}
