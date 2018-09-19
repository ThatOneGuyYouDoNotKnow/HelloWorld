using System.Windows.Input;
using JetBrains.Annotations;

namespace ViewModels
{
    public class HelloWorldViewModel : BaseViewModel
    {
        public HelloWorldViewModel()
        {
            WriteHelloWorldCommand = new RelayCommand(WriteHelloWorld);
        }

        [NotNull]
        public ICommand WriteHelloWorldCommand { get; }

        public string Text { get; set; }

        private void WriteHelloWorld()
        {
            Text = "Hello World";
        }
    }
}
