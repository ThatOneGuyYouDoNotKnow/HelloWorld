﻿using System;
using System.Windows.Input;
using JetBrains.Annotations;
using NullGuard;

namespace ViewModels
{
    public class RelayCommand : ICommand
    {
        private bool _canExecute;
        [CanBeNull] private Predicate<object> _canExecuteHandler;
        [CanBeNull] private Action<object> _executeHandler;

        public RelayCommand([CanBeNull] Action executeHandler) : this(x => executeHandler?.Invoke(), DefaultCanExecute)
        {
        }

        public RelayCommand([CanBeNull] Action<object> executeHandler) : this(executeHandler, DefaultCanExecute)
        {
        }

        public RelayCommand([CanBeNull] Action<object> executeHandler, [CanBeNull] Predicate<object> canExecuteHandler)
        {
            _executeHandler = executeHandler;
            _canExecuteHandler = canExecuteHandler;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute([CanBeNull] [AllowNull] object parameter)
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

        public void Execute([CanBeNull] [AllowNull] object parameter)
        {
            _executeHandler?.Invoke(parameter);
        }

        ~RelayCommand()
        {
            _canExecuteHandler = _ => false;
            _executeHandler = _ => { };
        }

        private static bool DefaultCanExecute([CanBeNull] [AllowNull] object parameter) => true;
    }
}
