using System.Windows;
using ViewModels;

namespace Views
{
    public partial class HelloWorldView
    {
        public HelloWorldView()
        {
            InitializeComponent();
            DataContext = new HelloWorldViewModel();
        }

        private void SayHelloWorldButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is HelloWorldViewModel viewModel) || viewModel == null)
            {
                return;
            }

            if (viewModel.WriteHelloWorldCommand.CanExecute(this))
            {
                viewModel.WriteHelloWorldCommand.Execute(this);
            }
        }
    }
}
