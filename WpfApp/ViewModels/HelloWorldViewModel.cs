using System.Windows.Input;
using JetBrains.Annotations;
using Models;

namespace ViewModels
{
    public class HelloWorldViewModel : SavableBaseViewModel<HelloWorldModel>
    {
        public HelloWorldViewModel([NotNull] ICommandFactory commandFactory) : base(commandFactory)
        {
            WriteHelloWorldCommand = commandFactory.CreateRelayCommand(WriteHelloWorld);
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
