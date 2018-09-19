using System.Windows.Input;
using JetBrains.Annotations;

namespace ViewModels
{
    public class HelloWorldViewModel : BaseViewModel
    {
        [NotNull]
        public ICommand WriteHelloWorldCommand { get; }

        public string Text { get; set; }
    }
}
