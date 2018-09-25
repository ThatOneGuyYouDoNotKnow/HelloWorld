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
            Assert.ThrowsException<ArgumentException>(() => persistenceService.Save(new object(), "path"));
        }

        [TestMethod]
        public void SerializableObjectAtInvalidPath_EmptyPath_ArgumentException()
        {
            //arrange
            PersistenceService persistenceService = new PersistenceService();

            //assert
            Assert.ThrowsException<ArgumentException>(() => persistenceService.Save(new SerializableObject(), ""));
        }

        [TestMethod]
        public void SerializableObjectAtInvalidPath_InvalidPath_ArgumentException()
        {
            //arrange
            PersistenceService persistenceService = new PersistenceService();

            //assert
            Assert.ThrowsException<ArgumentException>(() => persistenceService.Save(new SerializableObject(), "invalidPath:"));
        }

        [TestMethod]
        public void SerializableObjectAtInvalidPath_ReadOnlyFile_ArgumentException()
        {
            //arrange
            const string pathToSaveTo = "relativeROFileName";
            PersistenceService persistenceService = new PersistenceService();
            if (File.Exists(pathToSaveTo))
            {
                File.SetAttributes(pathToSaveTo, FileAttributes.Normal);
                File.Delete(pathToSaveTo);
            }

            File.Create(pathToSaveTo);
            File.SetAttributes(pathToSaveTo, FileAttributes.ReadOnly);

            //assert
            Assert.ThrowsException<ArgumentException>(() => persistenceService.Save(new SerializableObject(), pathToSaveTo));
        }

        [TestMethod]
        public void SerializableObjectAtValidPath_FileCreated()
        {
            //arrange
            const string pathToSaveTo = "relativeTestFileName";
            if (File.Exists(pathToSaveTo))
            {
                File.Delete(pathToSaveTo);
            }

            PersistenceService persistenceService = new PersistenceService();
            SerializableObject objectToSave = new SerializableObject {TestString = "some text"};

            //act
            persistenceService.Save(objectToSave, pathToSaveTo);

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
