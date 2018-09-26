using DependencyInjection;
using ViewModels;

namespace Views
{
    public partial class HelloWorldView
    {
        public HelloWorldView()
        {
            InitializeComponent();
            DataContext = Locator.GetInstance<HelloWorldViewModel>();
        }
    }
}
