using DependencyInjection;

namespace ViewModels
{
    public class DependencyInjectionPackage : IDependencyInjectionPackage
    {
        public void Register(IDiContainer diContainer)
        {
            diContainer.Register<ICommandFactory, CommandFactory>();
        }
    }
}
