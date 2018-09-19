using System;
using System.Windows.Input;

namespace ViewModels
{
    public class RelayCommand : ICommand
    {
        private bool _canExecute;
        private Predicate<object> _canExecuteHandler;
        private Action<object> _executeHandler;

        public RelayCommand(Action executeHandler) : this(x => executeHandler?.Invoke(), DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> executeHandler) : this(executeHandler, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> executeHandler, Predicate<object> canExecuteHandler)
        {
            _executeHandler = executeHandler;
            _canExecuteHandler = canExecuteHandler;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null)
            {
                return false;
            }

            if (_canExecute == _canExecuteHandler(parameter))
            {
                return _canExecute;
            }

            _canExecute = !_canExecute;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _executeHandler?.Invoke(parameter);
        }

        ~RelayCommand()
        {
            _canExecuteHandler = _ => false;
            _executeHandler = _ => { };
        }

        private static bool DefaultCanExecute(object parameter) => true;
    }
}
