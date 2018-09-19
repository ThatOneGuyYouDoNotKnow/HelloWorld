using System;
using System.Windows.Input;
using JetBrains.Annotations;

namespace ViewModels
{
    public abstract class SavableBaseViewModel<T> : BaseViewModel
    {
        protected SavableBaseViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            LoadCommand = new RelayCommand(Load);
        }

        [NotNull]
        public ICommand SaveCommand { get; }

        [NotNull]
        public ICommand LoadCommand { get; }

        public string SaveLocation { get; set; }

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
