using JetBrains.Annotations;

namespace DependencyInjection
{
    public interface IDiContainer
    {
        [NotNull]
        T GetInstance<T>()
            where T : class;

        void RegisterScoped<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface;

        void RegisterSingleton<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface;

        void RegisterTransient<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface;
    }
}
