using System;
using System.Windows.Input;
using JetBrains.Annotations;

namespace ViewModels
{
    public interface ICommandFactory
    {
        [NotNull]
        ICommand CreateRelayCommand([CanBeNull] Action executeHandler);

        [NotNull]
        ICommand CreateRelayCommand([CanBeNull] Action<object> executeHandler);

        [NotNull]
        ICommand CreateRelayCommand([CanBeNull] Action<object> executeHandler, [CanBeNull] Predicate<object> canExecuteHandler);
    }
}
