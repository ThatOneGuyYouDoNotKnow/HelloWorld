using System;
using System.IO;
using System.Runtime.Serialization;
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

        [TestMethod]
        [Ignore]
        public void SerializableObjectAtInvalidPath_ArgumentException()
        {
            //arrange
            PersistenceService persistenceService = new PersistenceService();

            //assert
            Assert.ThrowsException<ArgumentException>(() => persistenceService.Save(new SerializableObject(), "invalidPath"));
        }

        [TestMethod]
        [Ignore]
        public void SerializableObjectAtValidPath_FileCreated()
        {
            //arrange
            const string pathToSaveTo = "validPath"; //todo: set an actually valid path
            PersistenceService persistenceService = new PersistenceService();

            //act
            persistenceService.Save(new SerializableObject(), pathToSaveTo);

            //assert
            Assert.IsTrue(File.Exists(pathToSaveTo));
        }

        [DataContract]
        private class SerializableObject
        {
            [DataMember]
            public string TestString { get; set; }
        }
    }
}
