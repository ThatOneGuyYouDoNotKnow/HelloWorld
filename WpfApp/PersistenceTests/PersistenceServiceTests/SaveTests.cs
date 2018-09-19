using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace PersistenceTests.PersistenceServiceTests
{
    [TestClass]
    [Ignore]
    public class SaveTests
    {
        [TestMethod]
        public void ObjectNotJSONSerializable_InvalidOperationException()
        {
            //arrange
            PersistenceService persistenceService = new PersistenceService();

            //assert
            Assert.ThrowsException<InvalidOperationException>(() => persistenceService.Save(new object()));
        }
    }
}
