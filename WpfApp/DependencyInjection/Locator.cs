using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace DependencyInjection
{
    public static class Locator
    {
        [NotNull]
        private static IDiContainer DiContainer { get; } = new DiContainer();

        public static void Register<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface
        {
            DiContainer.Register<TInterface, TType>();
        }

        public static void RegisterSingleton<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface
        {
            DiContainer.RegisterSingleton<TInterface, TType>();
        }

        /// <summary>
        ///     registers all dependencies that are specified in an <see cref="IDependencyInjectionPackage" />
        /// </summary>
        public static void RegisterPackages()
        {
            IEnumerable<Type> diContainerPackages = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly =>
                assembly.GetTypes().Where(type => typeof(IDependencyInjectionPackage).IsAssignableFrom(type)));
            foreach (Type diContainerPackageType in diContainerPackages)
            {
                if (diContainerPackageType.IsInterface)
                {
                    continue;
                }

                IDependencyInjectionPackage diContainerPackage = (IDependencyInjectionPackage) Activator.CreateInstance(diContainerPackageType);
                diContainerPackage.Register(DiContainer);
            }
        }

        public static T GetInstance<T>()
            where T : class =>
            DiContainer.GetInstance<T>();
    }
}
