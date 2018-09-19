using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Persistence
{
    public class PersistenceService
    {
        public void Save([NotNull] object objectToSave, [NotNull] string pathToSaveTo)
        {
            if (!objectToSave.GetType().GetCustomAttributes(typeof(DataContractAttribute), true).Any())
            {
                throw new ArgumentException($"{objectToSave} needs the {nameof(DataContractAttribute)}");
            }

            if (!IsValidPath(pathToSaveTo))
            {
                throw new ArgumentException($"{pathToSaveTo} has to be a valid path");
            }

            throw new NotImplementedException();
        }

        private bool IsValidPath([NotNull] string pathToSaveTo)
        {
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

            if (fileInfo is null || fileInfo.IsReadOnly || fileInfo.DirectoryName != fileInfo.Name)
            {
                // file name is not valid
                return false;
            }


            return true;
        }

        [NotNull]
        public object Load(string pathToLoadFrom) => throw new NotImplementedException();
    }
}
