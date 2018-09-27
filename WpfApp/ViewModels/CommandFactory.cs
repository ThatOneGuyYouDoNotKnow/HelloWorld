using System;
using System.Windows.Input;
using JetBrains.Annotations;
using NullGuard;

namespace ViewModels
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateRelayCommand([CanBeNull] Action executeHandler)
        {
            return CreateRelayCommand(x => executeHandler?.Invoke(), DefaultCanExecute);
        }

        public ICommand CreateRelayCommand([CanBeNull] Action<object> executeHandler) => CreateRelayCommand(executeHandler, DefaultCanExecute);

        public ICommand CreateRelayCommand([CanBeNull] Action<object> executeHandler, [CanBeNull] Predicate<object> canExecuteHandler) =>
            new RelayCommand(executeHandler, canExecuteHandler);

        private static bool DefaultCanExecute([CanBeNull] [AllowNull] object parameter) => true;
    }
}
