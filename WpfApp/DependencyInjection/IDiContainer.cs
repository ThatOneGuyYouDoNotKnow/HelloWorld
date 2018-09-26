﻿using JetBrains.Annotations;

namespace DependencyInjection
{
    public interface IDiContainer
    {
        [NotNull]
        T GetInstance<T>()
            where T : class;

        void RegisterSingleton<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface;

        void Register<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface;
    }
}
