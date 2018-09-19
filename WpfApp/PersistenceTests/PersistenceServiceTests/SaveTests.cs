using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace PersistenceTests.PersistenceServiceTests
{
    [TestClass]
    public class SaveTests
    {
        [TestMethod]
        public void ObjectNotJSONSerializable_ArgumentException()
        {
            //arrange
            PersistenceService persistenceService = new PersistenceService();

            //assert
            Assert.ThrowsException<ArgumentException>(() => persistenceService.Save(new object(), "invalidPath"));
        }
    }
}
