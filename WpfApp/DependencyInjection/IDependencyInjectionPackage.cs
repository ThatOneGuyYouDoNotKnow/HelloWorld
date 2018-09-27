using JetBrains.Annotations;

namespace DependencyInjection
{
    public interface IDependencyInjectionPackage
    {
        void Register([NotNull] IDiContainer diContainer);
    }
}
