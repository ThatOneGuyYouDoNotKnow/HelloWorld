using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace DependencyInjection
{
    internal class DiContainer : Container, IDiContainer
    {
        internal DiContainer()
        {
            Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        public void RegisterTransient<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface
        {
            Register<TInterface, TType>(Lifestyle.Transient);
        }

        public void RegisterScoped<TInterface, TType>()
            where TInterface : class
            where TType : class, TInterface
        {
            Register<TInterface, TType>(Lifestyle.Scoped);
        }
    }
}
