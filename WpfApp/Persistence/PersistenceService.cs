using System;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Persistence
{
    public class PersistenceService
    {
        public void Save([NotNull] object objectToSave, string pathToSaveTo)
        {
            if (!objectToSave.GetType().GetCustomAttributes(typeof(DataContractAttribute), true).Any())
            {
                throw new ArgumentException($"{objectToSave} needs the {nameof(DataContractAttribute)}");
            }

            throw new NotImplementedException();
        }

        [NotNull]
        public object Load(string pathToLoadFrom) => throw new NotImplementedException();
    }
}
