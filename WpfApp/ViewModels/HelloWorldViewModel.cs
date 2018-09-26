﻿using System.Windows.Input;
using JetBrains.Annotations;
using Models;
using NullGuardUnfriendly;

namespace ViewModels
{
    public class HelloWorldViewModel : SavableBaseViewModel<HelloWorldModel>
    {
        public HelloWorldViewModel()
        {
            WriteHelloWorldCommand = new RelayCommand(WriteHelloWorld);
        }

        [NotNull]
        public ICommand WriteHelloWorldCommand { get; }

        [NotNull]
        public string Text
        {
            get => SavableModel.Text;
            set => SavableModel.Text = value;
        }

        private void WriteHelloWorld()
        {
            Text = "Hello World";
        }
    }
}
