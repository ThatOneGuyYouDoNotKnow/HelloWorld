using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            LoadAllAssemblies();

            IEnumerable<Type> diContainerPackages = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly =>
                assembly.GetTypes().Where(type => typeof(IDependencyInjectionPackage).IsAssignableFrom(type)));
            foreach (Type diContainerPackageType in diContainerPackages)
            {
                if (diContainerPackageType.IsInterface)
                {
                    continue;
                }

                ((IDependencyInjectionPackage) Activator.CreateInstance(diContainerPackageType)).Register(DiContainer);
            }
        }

        private static void LoadAllAssemblies()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                LoadReferencedAssemblies(assembly);
            }
        }

        private static void LoadReferencedAssemblies([NotNull] Assembly parentAssembly)
        {
            foreach (AssemblyName assemblyName in parentAssembly.GetReferencedAssemblies())
            {
                if (AppDomain.CurrentDomain.GetAssemblies().Any(a => a?.FullName == assemblyName.FullName))
                {
                    continue;
                }

                Assembly assembly = AppDomain.CurrentDomain.Load(assemblyName);
                LoadReferencedAssemblies(assembly);
            }
        }

        [NotNull]
        public static T GetInstance<T>()
            where T : class =>
            DiContainer.GetInstance<T>();
    }
}
