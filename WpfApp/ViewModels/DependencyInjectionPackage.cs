using DependencyInjection;

namespace ViewModels
{
    public class DependencyInjectionPackage : IDependencyInjectionPackage
    {
        public void Register(IDiContainer diContainer)
        {
            diContainer.RegisterSingleton<ICommandFactory, CommandFactory>();
        }
    }
}
