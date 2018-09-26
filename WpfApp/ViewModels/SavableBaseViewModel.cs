using System;
using System.Windows.Input;
using JetBrains.Annotations;
using NullGuardUnfriendly;

namespace ViewModels
{
    public abstract class SavableBaseViewModel<T> : BaseViewModel
        where T : new()
    {
        protected SavableBaseViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            LoadCommand = new RelayCommand(Load);
            SavableModel = new T();
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
