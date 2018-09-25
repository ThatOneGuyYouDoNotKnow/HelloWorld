using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Extensions;
using JetBrains.Annotations;

namespace Persistence
{
    public class PersistenceService
    {
        public void Save([NotNull] object objectToSave, [NotNull] string pathToSaveTo)
        {
            Type type = objectToSave.GetType();
            if (!type.GetCustomAttributes(typeof(DataContractAttribute), true).Any())
            {
                throw new ArgumentException(
                    $"{type} does not fulfill the requirement of {nameof(PersistenceService)} to posses the {nameof(DataContractAttribute)}.");
            }
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);

            using (FileStream stream = GetFileStream(pathToSaveTo))
            {
                serializer.WriteObject(stream, objectToSave);
            }
        }

        [NotNull]
        private static FileStream GetFileStream([NotNull] string pathToSaveTo)
        {
            if (pathToSaveTo.IsNullOrEmpty())
            {
                throw new ArgumentException("A path has to be specified.");
            }

            FileInfo fileInfo = null;
            try
            {
                fileInfo = new FileInfo(pathToSaveTo);
            }
            catch (ArgumentException)
            {
            }
            catch (PathTooLongException)
            {
            }
            catch (NotSupportedException)
            {
            }

            if (fileInfo is null)
            {
                throw new ArgumentException($"The path '{pathToSaveTo}' is not a valid path.");
            }

            if (fileInfo.DirectoryName == fileInfo.FullName)
            {
                throw new ArgumentException($"The path '{pathToSaveTo}' is a directory path, but a file path is needed.");
            }

            if (fileInfo.Exists && fileInfo.IsReadOnly)
            {
                throw new ArgumentException($"The path '{pathToSaveTo}' references a readonly file.");
            }

            return fileInfo.OpenWrite();
        }

        [NotNull]
        public object Load(string pathToLoadFrom) => throw new NotImplementedException();
    }
}
