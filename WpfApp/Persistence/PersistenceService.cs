﻿using System;
using JetBrains.Annotations;

namespace Persistence
{
    public class PersistenceService
    {
        public void Save([NotNull] object objectToSave)
        {
            throw new NotImplementedException();
        }

        [NotNull]
        public object Load(string pathToLoadFrom) => throw new NotImplementedException();
    }
}