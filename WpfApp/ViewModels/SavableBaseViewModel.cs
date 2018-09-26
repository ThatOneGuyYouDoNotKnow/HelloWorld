﻿using System;
using System.Windows.Input;
using DependencyInjection;
using JetBrains.Annotations;

namespace ViewModels
{
    public abstract class SavableBaseViewModel<T> : BaseViewModel
        where T : class, new()
    {
        protected SavableBaseViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            LoadCommand = new RelayCommand(Load);
            SavableModel = Locator.GetInstance<T>();
            SaveLocation = string.Empty;
        }

        [NotNull]
        public ICommand SaveCommand { get; }

        [NotNull]
        public ICommand LoadCommand { get; }

        [NotNull]
        public string SaveLocation { get; set; }

        [NotNull]
        protected T SavableModel { get; }

        private void Load()
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            throw new NotImplementedException();
        }
    }
}
