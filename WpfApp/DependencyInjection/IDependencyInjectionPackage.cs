namespace DependencyInjection
{
    public interface IDependencyInjectionPackage
    {
        void Register(IDiContainer diContainer);
    }
}
